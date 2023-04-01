using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects
{
    [Serializable]
    public class DomainObjectConstants
    {
        public static string PKWTypRessourceUriSchema = "res.pv://IPKWFahrzeugManager?tid={0}";
        public static string NKWTypRessourceUriSchema = "res.pv://INKWFahrzeugManager?tid={0}";
        public static string AchsenTypRessourceUriSchema = "res.pv://IAchsenManager?tid={0}";
        public static string MotorenTypRessourceUriSchema = "res.pv://IMotorenManager?tid={0}";
    }
}
