using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using PvKatalogsystem.Types.Interfaces;

namespace Absolute.SolrClient0900
{
    public class SolrCoreInfo
    {
        public SolrCoreInfo(Uri uri, ISolrSerializer serializer, ISolrIndex index)
        {
            Index = index;
            Uri = uri;
            Connection = new SolrConnection(uri);
            Commands = new SolrCommands(Connection);
            _serializer = serializer;
        }
        public string Name { get; set; }
        public string InstanceDir { get; set; }
        public string DataDir { get; set; }
        public int NumDocs { get; set; }
        public Uri Uri { get; set; }
        public SolrCommands Commands { get; set; }
        public SolrConnection Connection { get; set; }
        public ISolrIndex Index { get; private set; }
        private ISolrSerializer _serializer;

        public bool AddRange(ICollection<ISolrDocument> documents, bool commit = true)
        {
            var xdoc = new XmlDocument();
            try
            {
                var addElement = xdoc.CreateElement("add");
                foreach (var doc in documents)
                {
                    var xnode = _serializer.Serialize(doc, xdoc);
                    addElement.AppendChild(xnode);
                }
                xdoc.AppendChild(addElement);
                var result = Commands.Update(this, xdoc);
                if (commit)
                {
                    Commands.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                xdoc.Save("EvilDocuments_" + DateTime.Now.ToString("yyyyMMdd") + ".log");
                throw ex;
            }
        }

    }
}
