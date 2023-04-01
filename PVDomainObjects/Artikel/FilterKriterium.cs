using System;
using System.Collections.Generic;
using System.Linq;

namespace PV.DomainObjects.Artikel
{
    [Serializable]
    public class FilterKriterium
    {
        public String KritBez { get; set; }
        public String KritBezEinheit { get; set; }
        public String KritKurzBez { get; set; }
        public bool IsNameFettdruck { get; set; }
        public Int32 SelectionIndex { get; set; }
        private HashSet<string> _KritWerteHash = new HashSet<string>();

        public HashSet<String> KritWerteHash
        {
            get
            {
                return _KritWerteHash;
            }
            set
            {
                _KritWerteHash = value;
            }
        }

        public IList<string> KritWerte
        {
            get
            {
                try
                {
                    return KritWerteHash.OrderBy(item => decimal.Parse(item)).ToList().AsReadOnly();
                }
                catch
                {
                    return KritWerteHash.OrderBy(item => item).ToList().AsReadOnly();
                }
            }
        }
    }
}
