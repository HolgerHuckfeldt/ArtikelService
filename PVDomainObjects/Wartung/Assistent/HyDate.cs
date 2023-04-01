using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Wartung.Assistent
{
    [DataContract]
    public class HyDate
    {

        private static HyDate _noDate = new HyDate(0, 0);
        private static HyDate _maxDate = new HyDate(1, 99999);

        [DataMember]
        public int Month { get; set; }

        [DataMember]
        public int Year { get; set; }

        public HyDate()
        {

        }

        public HyDate(int m, int y)
        {
            Month = m;
            Year = y;
        }

        public HyDate(string s)
        {
            Parse(s);
        }

        private void Parse(string s)
        {
            s = s.Replace("/", "-").Replace("\\", "-").Replace(".", "-");

            if (s.Contains('-'))
            {
                var parts = s.Split('-');

                int iVal = 0;

                if (parts[0].Length == 4)
                {
                    int.TryParse(parts[0], out iVal);
                    Year = iVal;
                    int.TryParse(parts[1], out iVal);
                    Month = iVal;
                }
                else
                {
                    int.TryParse(parts[1], out iVal);
                    Year = iVal;
                    int.TryParse(parts[0], out iVal);
                    Month = iVal;
                }
            }
            else
            {
                int iVal = 0;
                int.TryParse(s, out iVal);
                Year = iVal;
            }
        }

        public static HyDate NoDate
        {
            get
            {
                return _noDate;
            }
        }

        public static HyDate MaxDate
        {
            get
            {
                return _maxDate;
            }
        }

        public static bool operator <(HyDate a, HyDate b)
        {
            if (a.Year == b.Year)
                return a.Month < b.Month;
            return a.Year < b.Year;
        }

        public static bool operator >(HyDate a, HyDate b)
        {
            if (a.Year == b.Year)
                return a.Month > b.Month;
            return a.Year > b.Year;
        }

        public static bool operator >=(HyDate a, HyDate b)
        {
            if (a == b)
                return true;
            return a > b;
        }

        public static bool operator <=(HyDate a, HyDate b)
        {
            if (a == b)
                return true;
            return a < b;
        }


        public static bool operator ==(HyDate a, HyDate b)
        {
            if (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null))
                return true;

            if (object.ReferenceEquals(a,null))
                return false;
            if (object.ReferenceEquals(b, null))
                return false;

            return (a.Year == b.Year) && (a.Month == b.Month);

        }

        public static bool operator !=(HyDate a, HyDate b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Year.GetHashCode() + Month.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is HyDate)
            {
                var a = obj as HyDate;
                return (a.Year == this.Year) && (a.Month == this.Month);
            }

            return false;
        }
        
    }
}
