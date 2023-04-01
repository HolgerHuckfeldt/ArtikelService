using PV.DomainObjectInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Wartung.Assistent
{
    [DataContract]
    public class MaintSystem : IFinderObject
    {
        [DataMember]
        public int Id;
        [DataMember]
        public string Name;
        [DataMember]
        public HyDate Von;
        [DataMember]
        public HyDate Bis;

        public HyDate VonDate
        {
            get
            {
                if (null == Von)
                    return HyDate.NoDate;
                return Von;
            }
        }

        public HyDate BisDate
        {
            get
            {
                if (null == Bis)
                    return HyDate.MaxDate;
                return Bis;
            }
        }

        public override string ToString()
        {
            return Name;
        }


        public string TestTag
        {
            get { return string.Empty; }
        }

        public string Description
        {
            get { return Name; }
        }

        public string Description2
        {
            get { return string.Empty; }
        }

        public string Description3
        {
            get { return string.Empty; }
        }

        public string Description4
        {
            get { return string.Empty; }
        }

        public string Description5
        {
            get { return string.Empty; }
        }

        public string Description6
        {
            get { return string.Empty; }
        }

        public string Description7
        {
            get { return string.Empty; }
        }

        public string Description8
        {
            get { return string.Empty; }
        }

        public string Description9
        {
            get { return string.Empty; }
        }

        public string Description10
        {
            get { return string.Empty; }
        }

        public string ParentID
        {
            get { return string.Empty; }
        }

        string IFinderObject.Id
        {
            get { return ""; }
        }

        public int Tiefe
        {
            get { return 0; }
        }

        public bool IsNew
        {
            get;
            set;
        }
    }
}
