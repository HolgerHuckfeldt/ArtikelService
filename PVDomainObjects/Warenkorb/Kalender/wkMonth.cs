using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb.Kalender
{
    [Serializable]
    public class wkMonth
    {
        List<wkWeek> _Weeks = new List<wkWeek>();
        private DateTime _FirstDayOfMonth;

        public wkMonth(DateTime today, Int32 monthAfterToday, IList<DateTime> NeinTage)
        {
            _FirstDayOfMonth = new DateTime(today.Year + ((today.Month + monthAfterToday - 1)/12),
                         (today.Month + monthAfterToday - 1)%12 + 1, 1);

            DateTime firstMonday =
                _FirstDayOfMonth.Subtract(TimeSpan.FromDays(_FirstDayOfMonth.DayOfWeek==DayOfWeek.Sunday?6:((Int32)_FirstDayOfMonth.DayOfWeek-1)));


            for (int i = 0; i < 6; ++i)
            {
                _Weeks.Add(new wkWeek(today, firstMonday.AddDays(7 * i), _FirstDayOfMonth.Month, NeinTage));
            }
        }

        public Boolean ContainsDay(wkDay day)
        {
            foreach (wkWeek week in _Weeks)
            {
                for(int i= 0;i<7;++i)
                {
                    if(week[i] == day)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        public wkWeek this[Int32 week]
        {
            get
            {
                return _Weeks[week];
            }
        }

        public Int32 Year
        {
            get
            {
                return _FirstDayOfMonth.Year;
            }
        }

        public Int32 Month
        {
            get
            {
                return _FirstDayOfMonth.Month;
            }
        }

        public String NameOfMonth
        {
            get
            {
                String[] names = new string[] { 
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_Januar"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_Februar"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_März"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_April"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_Mai"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_Juni"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_Juli"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_August"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_September"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_Oktober"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_November"),
					//Managers.TranslationManager.Translate("Common_Kalender_Monat_Dezember")
	
					"Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"
				
				};
                return names[Month-1];
            }
        }
    }
}
