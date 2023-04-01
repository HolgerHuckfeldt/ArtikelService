using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Globalization;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml.XPath;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PvKatalogsystem.Types.Interfaces;

namespace Absolute.SolrClient0900
{

    public interface ISolrConvert
    {
        object ConvertXml(XPathNodeIterator o, Dictionary<string, string> dynamicFieldMap);
        object ConvertJson(JToken o, Dictionary<string, string> dynamicFieldMap); 
    }

    public class SolrSerializer<TDoc> : ISolrSerializer where TDoc : ISolrDocument
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IDictionary<string, PropertyInfo> _documentFields;

        public static void RegisterTypeKonverter(Type t, ISolrConvert converter)
        {
            if (!KnownTypes.ContainsKey(t))
            {
                KnownTypes.Add(t, converter);
            }                
        }

        private static readonly Dictionary<Type, ISolrConvert> KnownTypes = new Dictionary<Type, ISolrConvert>();

        internal SolrSerializer(IDictionary<string, PropertyInfo> documentFields)
        {
            _documentFields = documentFields;
        }

        public XmlElement Serialize(ISolrDocument document, XmlDocument xdoc)
        {
            if (!(document is TDoc))
            {
                throw new Exception(string.Format("Das übergebene Dokument ist nicht vom Typ '{0}'.", typeof(TDoc)));
            }
            var docElement = xdoc.CreateElement("doc");
            foreach (var field in _documentFields)
            {
                var value = field.Value.GetValue(document, null);
                if (value == null)
                {
                    continue;
                }
                AppendSerializedField(docElement, field.Key, field.Value.PropertyType, value);
            }
            return docElement;
        }

        public SolrQueryResult<TDoc> Deserialize(Stream stream, SolrQueryDescription<TDoc> queryDesc)
        {

            var docType = typeof(TDoc);
            var result = new SolrQueryResult<TDoc>(queryDesc);

            var xPathDoc = new XPathDocument(stream);
            var xMainNav = xPathDoc.CreateNavigator();
            xMainNav.MoveToFirstChild(); // response
            if (xMainNav.Name != "response")
            {
                return result;
            }

            // Infos
            result.QueryTime = xMainNav.SelectSingleNode("lst[@name='responseHeader']/int[@name='QTime']").ValueAsInt;
            xMainNav = xMainNav.SelectSingleNode("result");
            result.NumFound = xMainNav.SelectSingleNode("@numFound").ValueAsInt;
            result.StartIndex = xMainNav.SelectSingleNode("@start").ValueAsInt;

            // Dokumente
            var xSolrDoc = xMainNav.Select("doc");

            Dictionary<string, string> dynamicFieldMap = new Dictionary<string, string>();
            foreach (var dynamicFieldKey in queryDesc.DynamicFieldKeys)
            {
                dynamicFieldMap.Add(dynamicFieldKey.Value,dynamicFieldKey.Key );
            }

            while (xSolrDoc.MoveNext())
            {
                var xField = xSolrDoc.Current.SelectChildren(XPathNodeType.Element);

                bool added = false;

                if (KnownTypes.ContainsKey(docType))
                {
                    try
                    {
                        var newDoc = (TDoc) KnownTypes[docType].ConvertXml(xField, dynamicFieldMap);
                        if (newDoc != null)
                        {
                            result.Documents.Add(newDoc);
                            added = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                        added = false;
                    }                    
                }

                if(!added)
                {
                    var doc = Activator.CreateInstance(docType);

                    while (xField.MoveNext())
                    {
                        var fieldNode = xField.Current;
                        var fieldNodeName = fieldNode.SelectSingleNode("@name").Value;
                        PropertyInfo field = null;
                        if (queryDesc.DynamicFieldKeys.Any(x => x.Value == fieldNodeName))
                        {
                            fieldNodeName = queryDesc.DynamicFieldKeys.First(x => x.Value == fieldNodeName).Key;
                        }
                        if (_documentFields.ContainsKey(fieldNodeName))
                        {
                            field = _documentFields[fieldNodeName];
                        }
                        else
                        {
                            continue;
                        }
                        if (field.PropertyType.IsGenericType && field.PropertyType.GetInterface("IEnumerable") != null)
                        {
                            var genericArguments = field.PropertyType.GetGenericArguments();
                            var argumentType = genericArguments[0];
                            var listType = typeof (List<>);
                            var list = field.GetValue(doc, null);
                            if (list == null)
                            {
                                list = Activator.CreateInstance(listType.MakeGenericType(argumentType));
                                field.SetValue(doc, list, null);
                            }
                            if (fieldNode.Name == "arr")
                            {
                                var xArr = fieldNode.SelectChildren(XPathNodeType.Element);
                                while (xArr.MoveNext())
                                {
                                    var arrNode = xArr.Current;
                                    var value = GetNodeValue(arrNode);
                                    field.PropertyType.InvokeMember("Add", BindingFlags.InvokeMethod, null, list,
                                        new object[] {Convert.ChangeType(value, argumentType)});
                                }
                            }
                            else
                            {
                                var value = GetNodeValue(fieldNode);
                                field.PropertyType.InvokeMember("Add", BindingFlags.InvokeMethod, null, list,
                                    new object[] {Convert.ChangeType(value, argumentType)});
                            }
                        }
                        else
                        {
                            var type = field.PropertyType;
                            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
                            {
                                type = type.GetGenericArguments()[0];
                            }
                            var value = GetNodeValue(fieldNode);
                            if (!string.IsNullOrEmpty(value))
                            {
                                field.SetValue(doc, Convert.ChangeType(value, type), null);
                            }
                        }

                    }
                    result.Documents.Add((TDoc) doc);
                }
            }
            xMainNav.MoveToNext();


            // Facets
            if (xMainNav.SelectSingleNode("@name").Value == "facet_counts")
            {
                var xFacetNodes = xMainNav.Select("lst[@name='facet_fields']/lst");
                while (xFacetNodes.MoveNext())
                {
                    var facetNode = xFacetNodes.Current;
                    var fieldName = facetNode.SelectSingleNode("@name").Value;
                    var facetQuery = queryDesc.FacetQueries.SingleOrDefault(x => x.FieldName == fieldName);
                    if (facetQuery == null)
                    {
                        continue;
                    }
                    var facetResult = new SolrFacetResult(facetQuery);
                    var xCountNodes = facetNode.SelectChildren(XPathNodeType.Element);
                    while (xCountNodes.MoveNext())
                    {
                        var countNode = xCountNodes.Current;
                        facetResult.Counts.Add(countNode.SelectSingleNode("@name").Value, countNode.ValueAsInt);
                    }
                    result.Facets.Add(facetResult);
                }
                xMainNav.MoveToNext();
            }

            // Highlights
            if (xMainNav.SelectSingleNode("@name").Value == "highlighting")
            {
                var xHighlighNodes = xMainNav.Select("lst");
                while (xHighlighNodes.MoveNext())
                {
                    var idNode = xHighlighNodes.Current;
                    var id = idNode.SelectSingleNode("@name").Value;
                    var fieldList = new Dictionary<string, ICollection<string>>();
                    result.Highlights.Add(id, fieldList);
                    var xFieldNodes = idNode.Select("arr");
                    while (xFieldNodes.MoveNext())
                    {
                        var fieldNode = xFieldNodes.Current;
                        var fieldName = fieldNode.SelectSingleNode("@name").Value;
                        var valueList = new List<string>();
                        fieldList.Add(fieldName, valueList);
                        var xValueNodes = fieldNode.Select("str");
                        while (xValueNodes.MoveNext())
                        {
                            var valueNode = xValueNodes.Current;
                            var value = valueNode.Value;
                            valueList.Add(value);
                        }
                    }
                }
            }

            return result;
        }



        public SolrQueryResult<TDoc> DeserializeJson(Stream stream, SolrQueryDescription<TDoc> queryDesc)
        {
            

            var docType = typeof(TDoc);
            var result = new SolrQueryResult<TDoc>(queryDesc);

            JsonReader jr = new JsonTextReader(new StreamReader(stream));
            var serializer = new JsonSerializer();
            JObject answer = serializer.Deserialize<JObject>(jr);

            var header = answer.SelectToken("responseHeader");

            result.QueryTime = header.SelectToken("QTime").Value<int>();

            var docs = answer.SelectToken("response");

            result.NumFound = docs.SelectToken("numFound").Value<int>();
            result.StartIndex = docs.SelectToken("start").Value<int>();

            Dictionary<string, string> dynamicFieldMap = new Dictionary<string, string>();
            foreach (var dynamicFieldKey in queryDesc.DynamicFieldKeys)
            {
                dynamicFieldMap.Add(dynamicFieldKey.Value, dynamicFieldKey.Key);
            }

            // Dokumente
            var xSolrDoc = docs.SelectToken("docs");
            foreach (var xField in xSolrDoc.Children())
            {

                if (KnownTypes.ContainsKey(typeof (TDoc)))
                {
                    var ob = KnownTypes[typeof(TDoc)].ConvertJson(xField, dynamicFieldMap);
                }

                var doc = Activator.CreateInstance(docType);

                foreach (var fdNode in xField)
                {
                    
                    if (fdNode is JProperty)
                    {
                        var fieldNode = fdNode as JProperty;


                        var fieldNodeName = fieldNode.Name;
                       
                        PropertyInfo field = null;
                        if (queryDesc.DynamicFieldKeys.Any(x => x.Value == fieldNodeName))
                        {
                            fieldNodeName = queryDesc.DynamicFieldKeys.First(x => x.Value == fieldNodeName).Key;
                        }
                        if (_documentFields.ContainsKey(fieldNodeName))
                        {
                            field = _documentFields[fieldNodeName];
                        }
                        else
                        {
                            continue;
                        }
                        if (field.PropertyType.IsGenericType && field.PropertyType.GetInterface("IEnumerable") != null)
                        {
                            var genericArguments = field.PropertyType.GetGenericArguments();
                            var argumentType = genericArguments[0];
                            var listType = typeof (List<>);
                            var list = field.GetValue(doc, null);
                            if (list == null)
                            {
                                list = Activator.CreateInstance(listType.MakeGenericType(argumentType));
                                field.SetValue(doc, list, null);
                            }
                            if (fieldNode.Value is JArray)
                            {
                                foreach (var arrNode in fieldNode.Value)
                                {
                                    var value = arrNode.Value<string>();
                                    if (argumentType == typeof (decimal) || argumentType == typeof (double))
                                        value = value.Replace(".", ",");

                                    field.PropertyType.InvokeMember("Add", BindingFlags.InvokeMethod, null, list,
                                        new object[] { Convert.ChangeType(value, argumentType) });
                                }
                            }
                            else
                            {
                                var value = fieldNode.Value<string>();
                                if (argumentType == typeof(decimal) || argumentType == typeof(double))
                                    value = value.Replace(".", ",");

                                field.PropertyType.InvokeMember("Add", BindingFlags.InvokeMethod, null, list,
                                    new object[] { Convert.ChangeType(value, argumentType) });
                            }
                        }
                        else
                        {
                            var type = field.PropertyType;
                            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>))
                            {
                                type = type.GetGenericArguments()[0];
                            }

                            var value = String.Empty;
                            if (fieldNode.Value is JArray)
                            {
                                foreach (var vItem in fieldNode.Value)
                                {
                                    value = value + vItem.Value<string>();
                                }

                            }
                            else
                                value = fieldNode.Value.Value<string>();

                            if (type == typeof(decimal) || type == typeof(double))
                                value = value.Replace(".", ",");

                            if (!string.IsNullOrEmpty(value))
                            {
                                field.SetValue(doc, Convert.ChangeType(value, type), null);
                            }
                        }
                    }

                }
                result.Documents.Add((TDoc)doc);
            }
            //xMainNav.MoveToNext();

            var xSolrFac = answer.SelectToken("facet_counts");

            if( xSolrFac != null)
            {
                var facetFields = xSolrFac.SelectToken("facet_fields");

                foreach (var fdNode in facetFields.Children())
                {


                    if (fdNode is JProperty)
                    {
                        var fieldNode = fdNode as JProperty;


                        var fieldName = fieldNode.Name;
                        var facetQuery = queryDesc.FacetQueries.SingleOrDefault(x => x.FieldName == fieldName);
                        if (facetQuery == null)
                        {
                            continue;
                        }

                        var facetResult = new SolrFacetResult(facetQuery);
                        foreach (var countNode in fdNode.Children())
                        {
                            if (countNode is JProperty)
                                facetResult.Counts.Add((countNode as JProperty).Value<string>(),
                                    (countNode as JProperty).Value<int>());

                            if (countNode is JArray)
                            {

                                foreach (var child in countNode.Children())
                                {
                                    facetResult.Counts.Add(child.Value<string>(),
                                        (child.Value<int>()));
                                }

                            }
                        }

                    }


                }

                //var fieldName = xField.SelectSingleNode("@name").Value;
                //var facetQuery = queryDesc.FacetQueries.SingleOrDefault(x => x.FieldName == fieldName);
                //if (facetQuery == null)
                //{
                //    continue;
                //}
                //var facetResult = new SolrFacetResult(facetQuery);
                //var xCountNodes = facetNode.SelectChildren(XPathNodeType.Element);
                //while (xCountNodes.MoveNext())
                //{
                //    var countNode = xCountNodes.Current;
                //    facetResult.Counts.Add(countNode.SelectSingleNode("@name").Value, countNode.ValueAsInt);
                //}
                //result.Facets.Add(facetResult);
            }
            // Facets
            //if (xMainNav.SelectSingleNode("@name").Value == "facet_counts")
            //{
            //    var xFacetNodes = xMainNav.Select("lst[@name='facet_fields']/lst");
            //    while (xFacetNodes.MoveNext())
            //    {
            //        var facetNode = xFacetNodes.Current;
            //        var fieldName = facetNode.SelectSingleNode("@name").Value;
            //        var facetQuery = queryDesc.FacetQueries.SingleOrDefault(x => x.FieldName == fieldName);
            //        if (facetQuery == null)
            //        {
            //            continue;
            //        }
            //        var facetResult = new SolrFacetResult(facetQuery);
            //        var xCountNodes = facetNode.SelectChildren(XPathNodeType.Element);
            //        while (xCountNodes.MoveNext())
            //        {
            //            var countNode = xCountNodes.Current;
            //            facetResult.Counts.Add(countNode.SelectSingleNode("@name").Value, countNode.ValueAsInt);
            //        }
            //        result.Facets.Add(facetResult);
            //    }
            //    xMainNav.MoveToNext();
            //}

            //// Highlights
            //if (xMainNav.SelectSingleNode("@name").Value == "highlighting")
            //{
            //    var xHighlighNodes = xMainNav.Select("lst");
            //    while (xHighlighNodes.MoveNext())
            //    {
            //        var idNode = xHighlighNodes.Current;
            //        var id = idNode.SelectSingleNode("@name").Value;
            //        var fieldList = new Dictionary<string, ICollection<string>>();
            //        result.Highlights.Add(id, fieldList);
            //        var xFieldNodes = idNode.Select("arr");
            //        while (xFieldNodes.MoveNext())
            //        {
            //            var fieldNode = xFieldNodes.Current;
            //            var fieldName = fieldNode.SelectSingleNode("@name").Value;
            //            var valueList = new List<string>();
            //            fieldList.Add(fieldName, valueList);
            //            var xValueNodes = fieldNode.Select("str");
            //            while (xValueNodes.MoveNext())
            //            {
            //                var valueNode = xValueNodes.Current;
            //                var value = valueNode.Value;
            //                valueList.Add(value);
            //            }
            //        }
            //    }
            //}

            return result;
        }


        public SolrQueryResult<TDoc> Deserialize(XmlDocument xdoc, SolrQueryDescription<TDoc> queryDesc)
        {
            var docType = typeof(TDoc);
            var result = new SolrQueryResult<TDoc>(queryDesc);

            // Infos
            result.QueryTime = int.Parse(xdoc.SelectSingleNode("/response/lst[@name='responseHeader']/int[@name='QTime']").InnerText);
            result.NumFound = int.Parse(xdoc.SelectSingleNode("/response/result/@numFound").Value);
            result.StartIndex = int.Parse(xdoc.SelectSingleNode("/response/result/@start").Value);


            // Dokumente
            var docNodes = xdoc.SelectNodes("/response/result/doc");
            foreach (XmlNode docNode in docNodes)
            {
                var doc = Activator.CreateInstance(docType);
                foreach (XmlNode fieldNode in docNode.ChildNodes)
                {
                    var fieldNodeName = fieldNode.SelectSingleNode("@name").Value;
                    var field = (PropertyInfo)null;
                    foreach (var kvp in _documentFields)
                    {
                        if (kvp.Key == fieldNodeName || Regex.IsMatch(fieldNodeName, "^" + kvp.Key.Replace("*", ".*") + "$"))
                        {
                            field = kvp.Value;
                            break;
                        }
                    }
                    if (field == null)
                    {
                        continue;
                    }
                    if (field.PropertyType.IsGenericType && field.PropertyType.GetInterface("IEnumerable") != null)
                    {
                        var genericArguments = field.PropertyType.GetGenericArguments();
                        var argumentType = genericArguments[0];
                        var listType = typeof(LinkedList<>);
                        var list = field.GetValue(doc, null);
                        if (list == null)
                        {
                            list = Activator.CreateInstance(listType.MakeGenericType(argumentType));
                            field.SetValue(doc, list, null);
                        }
                        if (fieldNode.Name == "arr")
                        {
                            foreach (XmlNode arrNode in fieldNode.ChildNodes)
                            {
                                var value = GetNodeValue(arrNode);
                                field.PropertyType.InvokeMember("Add", BindingFlags.InvokeMethod, null, list, new object[] { Convert.ChangeType(value, argumentType) });
                            }
                        }
                    }
                    else
                    {
                        var type = field.PropertyType;
                        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            type = type.GetGenericArguments()[0];
                        }
                        var value = GetNodeValue(fieldNode);
                        field.SetValue(doc, Convert.ChangeType(XmlUnescape(value), type), null);
                    }
                }
                result.Documents.Add((TDoc)doc);
            }

            // Facets
            var facetNodes = xdoc.SelectNodes("/response/lst[@name='facet_counts']/lst[@name='facet_fields']/lst");
            if (facetNodes.Count > 0)
            {
                foreach (XmlNode facetNode in facetNodes)
                {
                    var fieldName = facetNode.SelectSingleNode("@name").Value;
                    var facetQuery = queryDesc.FacetQueries.SingleOrDefault(x => x.FieldName == fieldName);
                    if (facetQuery == null)
                    {
                        continue;
                    }
                    var facetResult = new SolrFacetResult(facetQuery);
                    foreach (XmlNode countNode in facetNode.ChildNodes)
                    {
                        facetResult.Counts.Add(countNode.SelectSingleNode("@name").Value, int.Parse(countNode.InnerText));
                    }
                    result.Facets.Add(facetResult);
                }
            }

            // Highlights
            var highlightNodes = xdoc.SelectNodes("/response/lst[@name='highlighting']/lst");
            if (highlightNodes.Count > 0)
            {
                foreach (XmlNode idNode in highlightNodes)
                {
                    var id = idNode.SelectSingleNode("@name").Value;
                    var fieldList = new Dictionary<string, ICollection<string>>();
                    result.Highlights.Add(id, fieldList);
                    foreach (XmlNode fieldNode in idNode.SelectNodes("arr"))
                    {
                        var fieldName = fieldNode.SelectSingleNode("@name").Value;
                        var valueList = new LinkedList<string>();
                        fieldList.Add(fieldName, valueList);
                        foreach (XmlNode valueNode in fieldNode.SelectNodes("str"))
                        {
                            var value = valueNode.InnerText;
                            valueList.AddLast(value);
                        }
                    }
                }
            }
            return result;
        }

        private string GetNodeValue(XmlNode node)
        {
            var value = node.InnerText;
            if (node.Name == "double")
            {
                value = value.Replace(".", ",");
            }
            return value;
        }


        private string GetNodeValue(XPathNavigator node)
        {
            var value = node.Value;
            if (node.Name == "double")
            {
                value = value.Replace(".", ",");
            }
            return value;
        }

        private void AppendSerializedField(XmlElement xmlElement, string fieldName, Type dataType, object dataObject)
        {
            if (dataType.IsGenericType && dataType.GetInterface("IEnumerable") != null)
            {
                foreach (var val in (IEnumerable)dataObject)
                {
                    if (val == null)
                    {
                        continue;
                    }
                    var attributeName = fieldName;
                    var genVal = val;
                    var genType = val.GetType();
                    // Dictionary
                    if (genType.Name == "KeyValuePair`2")
                    {
                        attributeName = attributeName.Replace("*", val.GetType().GetProperty("Key").GetValue(val, null).ToString());
                        genVal = val.GetType().GetProperty("Value").GetValue(val, null);
                        genType = genVal.GetType();
                    }

                    AppendSerializedField(xmlElement, attributeName, genType, genVal);
                }
            }
            else if (dataType == typeof(decimal) || dataType == typeof(Nullable<decimal>))
            {
                var text = ((decimal)dataObject).ToString("0.###", new CultureInfo("en-US"));
                xmlElement.AppendChild(CreateFieldElement(xmlElement.OwnerDocument, fieldName, text));
            }
            else if (dataType == typeof(DateTime) || dataType == typeof(Nullable<DateTime>))
            {
                var text = ((DateTime)dataObject).ToUniversalTime().ToString("u", DateTimeFormatInfo.InvariantInfo).Replace(" ", "T");
                xmlElement.AppendChild(CreateFieldElement(xmlElement.OwnerDocument, fieldName, text));
            }
            else
            {
                xmlElement.AppendChild(CreateFieldElement(xmlElement.OwnerDocument, fieldName, dataObject.ToString()));
            }

        }

        private XmlElement CreateFieldElement(XmlDocument doc, string attributeName, string value)
        {
            var fieldElement = doc.CreateElement("field");
            var fieldNameAttr = doc.CreateAttribute("name");
            fieldNameAttr.Value = attributeName;
            fieldElement.Attributes.Append(fieldNameAttr);
            fieldElement.InnerText = XmlEscape(value);
            return fieldElement;
        }

        private string XmlEscape(string value)
        {
            value = value.Replace("<", "&lt;");
            value = value.Replace(">", "&gt;");
            return value;
        }

        private string XmlUnescape(string value)
        {
            value = value.Replace("&lt;", "<");
            value = value.Replace("&gt;", ">");
            return value;
        }


    }

    public class Doc
    {
        public string Id { get; set; }
        public string AltteilKennzeichen { get; set; }
        public string Artikelnummer { get; set; }
        public string ArtikelnummerSuche { get; set; }
        public string Bezeichnung { get; set; }
        public bool HasMaterialCertification { get; set; }
        public string Hersteller { get; set; }
        public string HerstellerHLK { get; set; }
        public string HerstellerHLKSuche { get; set; }
        public int Herstellernummer { get; set; }
        public int DLNr { get; set; }
        public bool IsAltteil { get; set; }
        public bool IsIncentiveBundle { get; set; }
        public bool IsLieferbar { get; set; }
        public bool IsStahlgruberArtikel { get; set; }
        public bool IsPseudoartikel { get; set; }
        public bool IsRemanufacturedPart { get; set; }
        public bool IsSelfServicePackage { get; set; }
        public bool IsVerpackungseinheitGanzzahl { get; set; }
        public string Katalognummer { get; set; }
        public double Pfandwert { get; set; }
        public string PreiseinheitBezeichnung { get; set; }
        public double PreiseinheitMenge { get; set; }
        public double PreisEinheitUmrechnungsFaktor { get; set; }
        public int PvManagerGruppe { get; set; }
        public double MengenEinheitsFaktor { get; set; }
        public string TechnischeMengeneinheitBezeichnung { get; set; }
        public string VdbArtikelnummer { get; set; }
        public int VdbArtikelzustand { get; set; }
        public string VdbHerstellerkuerzel { get; set; }
        public double Verkaufspreis_0 { get; set; }
        public double Verkaufspreis_Kompass { get; set; }
        public double Verkaufspreis_KompassPitstop { get; set; }
        public double Verkaufspreis_KompassStahlgruber { get; set; }
        public string VerpackungseinheitBezeichnung { get; set; }
        public string Vorschaubild { get; set; }
        public string PitstopVorschaubild { get; set; }
        public string Warengruppe { get; set; }
        public List<string> Attribut { get; set; }
        public List<string> Matchcode { get; set; }
        public List<string> Referenznummer { get; set; }
        public List<string> Tauschartikel_001 { get; set; }
        public List<string> ReferenznummerEindeutig { get; set; }
        public List<string> Herstellersortiernummer { get; set; }
        public List<string> VergleichsnummerEindeutig { get; set; }
        public List<string> Dokument { get; set; }
        public List<string> VerwandteArtikel { get; set; }
        public List<string> GenerischerArtikel { get; set; }
        public List<string> VerwandteGenArtikel { get; set; }
        public List<string> CsoCode { get; set; }
        public List<string> Zusatzbezeichnung { get; set; }
        public List<string> Vergleichsnummer { get; set; }
        public List<string> Synonym { get; set; }
        public List<string> EaNummer { get; set; }
        public List<string> Logistikinfo { get; set; }
        public List<string> ReferenznummerSuche { get; set; }
        public List<string> EaNummerEindeutig { get; set; }
        public int? EinheitenProVerpackung { get; set; }
        public int? MengeProEinheit { get; set; }
        public string PitstopWarengruppe { get; set; }
        public List<string> Gebrauchsnummer { get; set; }
        public List<int?> Aktionsnummer { get; set; }
        public List<string> Attributblock_PC68193 { get; set; }
        public List<int?> AktionsnummerKundengruppe_80003 { get; set; }
        public List<string> GebrauchsnummerSuche { get; set; }
        public List<string> GebrauchsnummerEindeutig { get; set; }
        public List<string> Aktionsinfo { get; set; }
        public List<string> Link { get; set; }
        public List<string> Information { get; set; }
    }

    public class KnownTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return System.Attribute.GetCustomAttributes(objectType).Any(v => v is KnownTypeAttribute);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(objectType);  // Reflection. 

            // Displaying output. 
            foreach (System.Attribute attr in attrs)
            {
                if (attr is KnownTypeAttribute)
                {
                    KnownTypeAttribute k = (KnownTypeAttribute)attr;
                    var props = k.Type.GetProperties();
                    bool found = true;
                    foreach (var f in jObject)
                    {
                        if (!props.Any(z => z.Name == f.Key))
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                    {
                        var target = Activator.CreateInstance(k.Type);
                        serializer.Populate(jObject.CreateReader(), target);
                        return target;
                    }
                }
            }
            throw new Exception();


            // Populate the object properties

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}