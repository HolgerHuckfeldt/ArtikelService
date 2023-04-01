using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Technik
{
    [DataContract]
    public class KfzCallback : IComparable
    {
        [DataMember]
        public string HerstellerName
        {
            get;
            set;
        }
        [DataMember]
        public string ModelName
        {
            get;
            set;
        }
        [DataMember]
        public string ProduktionPeriod
        {
            get;
            set;
        }
        [DataMember]
        public string Reason
        {
            get;
            set;
        }
        [DataMember]
        public string Effect
        {
            get;
            set;
        }
        [DataMember]
        public string Remedy
        {
            get;
            set;
        }
        [DataMember]
        public string Vehicles
        {
            get;
            set;
        }
        [DataMember]
        public string Published
        {
            get;
            set;
        }
        [DataMember]
        public DateTime CreationDate
        {
            get;
            set;
        }
        [DataMember]
        public List<int> VehicleList
        {
            get;
            set;
        }

        [DataMember]
        public string Baugruppe
        {
            get;
            set;
        }
        [DataMember]
        public string InternerAktionsCode
        {
            get;
            set;
        }
        [DataMember]
        public string VollzugErkennbarAn
        {
            get;
            set;
        }


        #region IComparable Member

        public int CompareTo(object obj)
        {
            if( (obj as KfzCallback) == null)
                return -1;

            var parts = Published.Split(' ');
            if (parts.Length == 2)
            {
                var meinJahr = parts[1];
                var meinMonat = parts[0];

                var cparts = (obj as KfzCallback).Published.Split(' ');
                if (cparts.Length != 2)
                {
                    cparts = (obj as KfzCallback).Published.Split('/');
                }

                string seinJahr = string.Empty;

                if( cparts.Length >= 2)
                    seinJahr = cparts[1];

                var seinMonat = cparts[0];
                
                if (seinJahr != meinJahr)
                {
                    int mj = 0;
                    int sj = 0;
                    if (int.TryParse(meinJahr, out mj))
                    {
                        if (int.TryParse(seinJahr, out sj))
                        {
                            return mj.CompareTo(sj);
                        }
                    }
                    return -1;
                }

                int mm = GetMonat(meinMonat);
                int sm = GetMonat(seinMonat);

                return mm.CompareTo(sm);
            }
            else
                return 1;
        }


        private static int GetMonat(string text)
        {
            switch( text)
            {
                case "Januar":
                    return 1;
                case "Februar":
                    return 2;
                case "März":
                    return 3;
                case "April":
                    return 4;
                case "Mai":
                    return 5;
                case "Juni":
                    return 6;
                case "Juli":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "Oktober":
                    return 10;
                case "November":
                    return 11;
                case "Dezember":
                    return 12;

            }
            return 0;

        }

        #endregion
    }
}
