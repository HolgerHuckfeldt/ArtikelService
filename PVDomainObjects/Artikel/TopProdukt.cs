using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class TopProdukt : Artikel
    {
        public TopProdukt(Int32 topBonuspunkte, Decimal topBonusfaktor, Boolean isTopBonusByFactor, Boolean isPreisvorteil)
            : base()
        {
            _TopBonuspunkte = topBonuspunkte;
            _TopBonusfaktor = topBonusfaktor;
            _IsTopBonusByFactor = isTopBonusByFactor;
            _IsPreisvorteil = isPreisvorteil;
        }

        public TopProdukt()
        { }

        [DataMember]
        public Decimal TopPreisvorteil
        {
            get;
            set;
        }

        [DataMember]
        public Boolean IsTopPreisvorteil
        {
            get
            {
                return _IsPreisvorteil;
            }
            set
            {
                _IsPreisvorteil = value;
            }
        }

        // CR: bschuedzig: this element hides an ancestor with the same same
        // to make things worse, the signature differs!
        public Int32 TopBonuspunkte
        {
            get
            {
                return _IsPreisvorteil
                           ? 0
                           : (_IsTopBonusByFactor ? (Int32)(Umsatzbonuspunkte * (_TopBonusfaktor - 1m)) : _TopBonuspunkte);
            }
            set
            {
                _TopBonuspunkte = value;
            }
        }

        [DataMember]
        public bool IsTopBonusByFactor
        {
            get
            {
                return _IsTopBonusByFactor;
            }
            set
            {
                _IsTopBonusByFactor = value;
            }
        }

        [DataMember]
        public Decimal TopBonusfaktor
        {
            get
            {
                if (IsTopBonusByFactor)
                {
                    return _TopBonusfaktor;
                }

                if (Umsatzbonuspunkte > 0)
                {
                    return (TopBonuspunkte + Umsatzbonuspunkte) / Umsatzbonuspunkte;
                }

                return 1;
            }
            set
            {
                _TopBonusfaktor = value;
            }
        }

        [DataMember]
        public string TopProduktNotiz { get; set; }

    }
}
