#region

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PV.DomainObjects.Artikel;

#endregion

namespace PV.DomainObjects.KVA
{
    [Serializable]
    //[DataContract]
    [KnownType(typeof(ShallowArbeitsprozess))]
    public class ShallowInnerItem : ISerializable
    {
        [Serializable]
        //[DataContract]
        public class ShallowArbeitsprozess
        {

            //[DataMember]
            public string Beschreibung { get; set; }


            public ShallowArbeitsprozess(string beschreibung)
            {
                Beschreibung = beschreibung;
            }

            public ShallowArbeitsprozess()
            {
            }
        }

        public ShallowInnerItem(SerializationInfo info, StreamingContext ctxt)
        {
            var values = info.GetEnumerator();

            while (values.MoveNext())
            {
                switch (values.Name)
                {

                    case "_arbeitswertListe":
                    case "ArbeitswertListe":
                        ArbeitswertListe = values.Value as List<ShallowArbeitsprozess>;
                        break;
                    case "_hinweis":
                    case "Hinweis":
                        Hinweis = values.Value as string;
                        break;
                    case "_artikelKatalogIdent":
                    case "ArtikelKatalogIdent": 
                        ArtikelKatalogIdent = values.Value as ArtikelKatalogIdent;
                        break;
                    case "_awProH":
                    case "AwProH":
                        AwProH = (int) values.Value;
                        break;
                    case "Nummer":
                        Nummer = values.Value as string;
                        break;
                    case "KurzBeschreibung":
                        KurzBeschreibung = values.Value as string;
                        break;
                    case "Beschreibung":
                        Beschreibung = values.Value as string;
                        break;
                    case "Wert":
                        Wert = (double)values.Value;
                        break;
                    case "OriginalWert":
                        OriginalWert = (double)values.Value;
                        break;
                    case "Stunden":
                        Stunden = (double)values.Value;
                        break;
                    case "OriginalStunden":
                        OriginalStunden = (double)values.Value;
                        break;
                    case "ProzessartTag":
                        ProzessartTag = values.Value as string;
                        break;
                    default:
                        Console.WriteLine("Unbekanntes Attribute:" + values.Name);
                        break;
                }
            }
        }

        public ShallowInnerItem()
        {
            ArbeitswertListe = new List<ShallowArbeitsprozess>();
            Hinweis = "";
        }

        //[DataMember]
        public List<ShallowArbeitsprozess> ArbeitswertListe { get; set; }

        //[DataMember]
        public string Hinweis { get; set; }

        //[DataMember]
        public ArtikelKatalogIdent ArtikelKatalogIdent { get; set; }

        //[DataMember]
        public int AwProH { get; set; }

        //[DataMember]
        public string Nummer { get; set; }

        //[DataMember]
        public string KurzBeschreibung { get; set; }

        //[DataMember]
        public string Beschreibung { get; set; }

        //[DataMember]
        public double Wert { get; set; }

        //[DataMember]
        public double OriginalWert { get; set; }

        //[DataMember]
        public double Stunden { get; set; }

        //[DataMember]
        public double OriginalStunden { get; set; }

        //[DataMember]
        public string ProzessartTag { get; set; }

        #region ISerializable Member

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ArbeitswertListe", ArbeitswertListe);
            info.AddValue("Hinweis", Hinweis);
            info.AddValue("ArtikelKatalogIdent", ArtikelKatalogIdent);
            info.AddValue("AwProH", AwProH);
            info.AddValue("Nummer", Nummer);
            info.AddValue("KurzBeschreibung", KurzBeschreibung);
            info.AddValue("Beschreibung", Beschreibung);
            info.AddValue("Wert", Wert);
            info.AddValue("OriginalWert", OriginalWert);
            info.AddValue("Stunden", Stunden);
            info.AddValue("OriginalStunden", OriginalStunden);
            info.AddValue("ProzessartTag", ProzessartTag);


        }

        #endregion
    }
}