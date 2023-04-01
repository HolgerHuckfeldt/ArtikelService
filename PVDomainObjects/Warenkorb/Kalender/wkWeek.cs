using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb.Kalender
{
    [Serializable]
    public class wkWeek
    {
        private List<wkDay> _tage = new List<wkDay>();

        public wkWeek(DateTime today, DateTime mondayOfWeek, Int32 month, IList<DateTime> NeinTage)
        {
            if(mondayOfWeek.DayOfWeek != DayOfWeek.Monday)
            {
                throw new Exception("DateTime:mondayOfWeek muss ein Montag sein!");
            }

            CultureInfo myCI = new CultureInfo("de-DE");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = DayOfWeek.Sunday;
            KalenderWoche =  myCal.GetWeekOfYear(mondayOfWeek, myCWR, myFirstDOW );

            for(int i = 0; i < 7 ; ++i)
            {
                _tage.Add(new wkDay(today, mondayOfWeek.AddDays(i), month, NeinTage));
            }
        }

        public wkDay this[Int32 day]
        {
            get
            {
                return _tage[day];
            }
        }

        public Int32 KalenderWoche { get; private set; }
    }
}
