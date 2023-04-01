using System;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Artikel
{
    [Serializable] 
    public class ArtikelDokument
    {
        public string BezeichnungAnzeige
        {
            get
            {
                if ((Typ == DokumentenTyp.Einbauanleitung || Typ == DokumentenTyp.Sicherheitsdatenblatt) && Bezeichnung.CompareTo("Artikelbild") > -1)
                    return string.Empty;

                return Bezeichnung;
            }
            set
            {
                Bezeichnung = value;
            }
        }

        public string Bezeichnung { get; set; }
        public string Beschreibung { get; set; }
        public string Target { get; set; }
        
        public string TargetForUI
        {
            get
            {
                if (string.IsNullOrEmpty(Target))
                    return string.Empty;

                //PvImage pvImage = PvImage.FromTecDocArtikelDokument(DLNr, Target, null, null);
                //String weburi = ConfigManager.GetWebUriConstructor("tecdocdokument");

                //string strdlnr = DLNr.ToString();
                //while (strdlnr.Length < 3)
                //    strdlnr = "0" + strdlnr;

                //weburi = weburi.Replace("[extension]", Extension);
                //weburi = weburi.Replace("[dlnr]", strdlnr);
                //weburi = weburi.Replace("[target]", Target+"."+Extension);

                return string.Empty; // pvImage.ImageURI.ToString();
            }
        }

        public string Extension { get; set; }
        public int DLNr { get; set; }
        public DokumentenTyp Typ { get; set; }
    }
}
