using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using PvKatalogsystem.Types.Interfaces;

namespace Absolute.SolrClient0900
{
    public interface ISolrSerializer
    {
        XmlElement Serialize(ISolrDocument document, XmlDocument xdoc);
    }
}
