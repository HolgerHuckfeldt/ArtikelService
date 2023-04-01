using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Plus
{
    //[Serializable]
    public class PraemienArtikel : Artikel.Artikel
    {
        #region Properties
      
        public int AnzahlPunkte
        {
            get
            {
                return (int)(EKPreis * 100);
            }
        }

        //public List<PvImage> Bilder { get; set; }
        char[] trimchar = { '\n', '\r'};

        public String MarketingBeschreibung
        {
            get 
            {

                string tmp = "";
                foreach (var x in ArtikelInformationen)
                {
                    if(tmp!="")
                        tmp += "\n\n";
                    tmp += x.Key + "\n";
                    //strHelp = x.Value.TrimEnd(trimchar);
                    tmp += x.Value.TrimEnd(trimchar);
                }
                return (!string.IsNullOrEmpty(tmp)) ? tmp : string.Empty;
            }
        }

        public String MarketingBezeichnungAnzeige
        {
            get
            {
                if (MarketingBezeichnung.Length < 50)
                {
                    return MarketingBezeichnung;
                }

                return MarketingBezeichnung.Substring(0, 50) + " ...";
            }
        }

        public String ArtikelBeschreibung
        {
            get
            {
                string tmp = (from x in ArtikelInformationen where x.Key == "Allgemeine Information" select x.Value).FirstOrDefault();
                return (!string.IsNullOrEmpty(tmp)) ? tmp : string.Empty;
            }
        }
 

        #endregion Properties
    }
}
