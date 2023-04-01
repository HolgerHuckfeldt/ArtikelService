using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class ArtikelProviderResult<T> where T : Artikel
    {

        public ArtikelProviderResult(List<T> artikelListe, List<IncentiveArtikel> incentiveArtikel)
        {
            _ArtikelListe = artikelListe;
            _IncentiveListe = incentiveArtikel;
        }

        [DataMember]
        private List<StuecklistenArtikel> _StuecklistenArtikel;

        [DataMember]
        private List<T> _ArtikelListe;

        [DataMember]
        private List<IncentiveArtikel> _IncentiveListe;

        [DataMember]
        private OelEmpfehlung _OelEmpfehlungen;

        //Spellcheckdaten
        [DataMember]
        public List<SpellcheckResult> SpellcheckResult { get; set; }

        //Für Temot-Daten
        [DataMember]
        public String StripImageUri { get; set; }
        [DataMember]
        public Int32 ImgWidth { get; set; }
        [DataMember]
        public Int32 ImgHeight { get; set; }
        [DataMember]
        public List<TemotStripElement> StripElements { get; set; }
        [DataMember]
        public List<KeyValuePair<int, int>> StripElementsIdArticleIds { get; set; }

        public List<StuecklistenArtikel> StuecklistenArtikel
        {
            get
            {
                if (_StuecklistenArtikel == null)
                    _StuecklistenArtikel = new List<StuecklistenArtikel>();

                return _StuecklistenArtikel;
            }
            set
            {
                if (value != null)
                {
                    _StuecklistenArtikel = value;
                }
            }
        }

        public List<T> ArtikelListe 
        {
            get
            {
                if(_ArtikelListe == null)
                    _ArtikelListe = new List<T>();

                return _ArtikelListe;
            }
            set
            {
                if(value != null)
                {
                    _ArtikelListe = value;
                }
            }
        }

        public List<IncentiveArtikel> IncentiveListe
        {
            get
            {
                if(_IncentiveListe == null)
                    _IncentiveListe = new List<IncentiveArtikel>();

                return _IncentiveListe;
            }

            set
            {
                if (value != null)
                {
                    _IncentiveListe = value;
                }
            }
        }

        public OelEmpfehlung OelEmpfehlungen
        {
            get
            {
                if (_OelEmpfehlungen == null)
                    _OelEmpfehlungen = new OelEmpfehlung();

                return _OelEmpfehlungen;
            }

            set
            {
                if (value != null)
                {
                    _OelEmpfehlungen = value;
                }
            }
        }
    }
}
