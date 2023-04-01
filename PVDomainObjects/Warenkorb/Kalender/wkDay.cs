using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Warenkorb.Kalender
{
    [DataContract]
    [Serializable]
    public class wkDay : IEquatable<wkDay>
    {
        [DataMember]
        private DateTime _ThisDay;

        public wkDay(DateTime today, DateTime thisDay, Int32 month, IList<DateTime> NeinTage)
        {
            if (month == thisDay.Month)
            {
                if (thisDay.Date >= today.Date && thisDay.DayOfWeek != DayOfWeek.Saturday && thisDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (NeinTage != null)
                    {
                        IsValidDay = NeinTage.Contains(thisDay) ? false : true;
                        IsNeinTag = !IsValidDay;
                    }
                    else
                        IsValidDay = true;
                }
                IsDayOfMonth = true;
            }

            _ThisDay = thisDay;
        }

        public Int32 DayOfMonth
        {
            get
            {
                return _ThisDay.Day;
            }
        }

        [DataMember]
        public Boolean IsNeinTag { get; set; }

        [DataMember]
        public Boolean IsValidDay { get; set; }

        [DataMember]
        public Boolean IsDayOfMonth { get; private set; }

        
        public DateTime GetDateTime()
        {
            return _ThisDay;
        }

        #region IEquatable<wkDay> Member

        public bool Equals(wkDay other)
        {
            return other!=null && _ThisDay.Date == other._ThisDay.Date && IsDayOfMonth == other.IsDayOfMonth && IsValidDay == other.IsValidDay && IsNeinTag == other.IsNeinTag;
        }

        #endregion
    }
}
