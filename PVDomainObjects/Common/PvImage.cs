/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz  
 * Modul:    Modulübergreifend   
 * Funktionen: Kapselt die Informationen und die Funktionen eines Bildes
 *************************************************************************/

using System;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PV.DomainObjects.Common
{
    /// <summary>
    /// Kapselt die Informationen und die Funktionen eines Bildes
    /// </summary>
    [DataContract]
    [Serializable]
    public class PvImage : INotifyPropertyChanged
    {
        //static String _UriPfad = "http://bilder.pvkompass.de/";

        private static String _UriPfad = ""; //ConfigManager.GetWebUriConstructor("bilder1.pvkompass.de");
        private static String _UriPfadSensitive = ""; // ConfigManager.GetWebUriConstructor("bilder1.pvkompasssensitive.de");

        public static PvImage FromTecDocPraemienArtikelBild(Int64 dLNr, String bildname, String bildnummer, String filetyp)
        {
            return new PvImage(string.Format("{0}/KompassImage//600x600/{1}", _UriPfad, bildname));
        }

        public static PvImage FromTecDocSensitiveBild(String bildname)
        {
            return new PvImage(string.Format("{0}/Kompass/70x70/{1}", _UriPfadSensitive, bildname));
            //return new PvImage(string.Format("http://pvlivedigitalbilder.pvkompass.de/KompassImage//70x70/{0}", bildname));
            //return new PvImage(String.Format("pvimg://TecDocArtikelBild/parameters?dlnr={0}&bildname={1}&bildnummer={2}&filetyp={3}", dLNr.ToString("000"), bildname, bildnummer, filetyp));
        }

        public static PvImage FromTecDocArtikelBild(Int64 dLNr, String bildname, String bildnummer, String filetyp)
        {
            return new PvImage(string.Format("{0}/KompassImage//70x70/{1}", _UriPfad, bildname));
            //return new PvImage(string.Format("http://pvlivedigitalbilder.pvkompass.de/KompassImage//70x70/{0}", bildname));
            //return new PvImage(String.Format("pvimg://TecDocArtikelBild/parameters?dlnr={0}&bildname={1}&bildnummer={2}&filetyp={3}", dLNr.ToString("000"), bildname, bildnummer, filetyp));
        }

        public static PvImage FromTecDocArtikelZoomBild(Int64 dLNr, String bildname, String bildnummer, String filetyp)
        {
            return new PvImage(string.Format("{0}/KompassImage//600x600/{1}", _UriPfad, bildname));
            //return new PvImage(String.Format("pvimg://TecDocArtikelBild/parameters?dlnr={0}&bildname={1}&bildnummer={2}&filetyp={3}", dLNr.ToString("000"), bildname, bildnummer, filetyp));
        }

        public static PvImage FromTecDocArtikelSensitiveZoomBild(String bildname)
        {
            return new PvImage(string.Format("{0}/KompassImage/0x0/{1}", _UriPfadSensitive, bildname));
            //return new PvImage(String.Format("pvimg://TecDocArtikelBild/parameters?dlnr={0}&bildname={1}&bildnummer={2}&filetyp={3}", dLNr.ToString("000"), bildname, bildnummer, filetyp));
        }

        public static PvImage FromTecDocArtikelDokument(Int32 dLNr, String bildname, String bildnummer, String filetyp)
        {
            return new PvImage(string.Format("{0}/KompassGetDocument//{1}", _UriPfad, bildname));
            //return new PvImage(string.Format("http://www.pvkompass.de/Documents/{0}", bildname));
        }

        public static PvImage FromPimsPromotionLogo(String promotionLogo)
        {
            return new PvImage(string.Format("{0}/KompassImage//40x40/{1}", _UriPfad, promotionLogo));
            //return new PvImage(String.Format("http://pvbinarysystem/Handler/GetKompassImage.ashx?filename={0}&bildformat=_40x40", promotionLogo));
        }

        public static PvImage FromPimsPromotionArtikelBild(String bild, String thumb)
        {
            return new PvImage(string.Format("{0}/KompassImage//70x70/{1}", _UriPfad, bild));
            //return new PvImage(String.Format("http://www.pvkompass.de/Handler/ImageView.ashx?path1={0}&width=70&height=70&png=0&preserve=1", bild));
        }

        public static PvImage FromPimsIncentiveArtikelBild(Int32 dlnr, String bild, String thumb)
        {
            return new PvImage(string.Format("{0}/KompassImage//60x60/{1}", _UriPfad, bild));
            //return new PvImage(String.Format("pvimg://PimsIncentiveArtikelBild/parameters?dlnr={0}&bild={1}&thumb={2}", dlnr.ToString("000"), bild, thumb));
        }

        public static PvImage FromPimsIncentiveBundleBild(Int64 dlnr, String bild, String thumb)
        {
            return new PvImage(string.Format("{0}/KompassImage//60x60/{1}", _UriPfad, bild));
            //return new PvImage(String.Format("pvimg://PimsIncentiveBundleBild/parameters?dlnr={0}&bild={1}&thumb={2}", dlnr.ToString("000"), bild, thumb));
        }

        public static PvImage FromPimsHerstellerLogo(Int32 dlnr, String bild)
        {
            return new PvImage(string.Format("{0}/KompassImage//60x60/{1}", _UriPfad, bild));
            //return new PvImage(String.Format("pvimg://PimsHerstellerLogo/parameters?dlnr={0}&bild={1}", dlnr.ToString("000"), bild));
        }

        public static PvImage FromLMSTrainingsBild(String bildname)
        {
            //return new PvImage(String.Format("pvimg://LMSTrainingsBild/parameters?dlnr={0}&bildname={1}&filetyp={2}", dLNr.ToString("000"), bildname, filetyp));
            return new PvImage(string.Format("{0}/KompassImage//600x600/{1}", _UriPfad, bildname));
        }

        public static PvImage FromPims2HerstellerLogo(string name)
        {
            return new PvImage(string.Format("{0}/KompassImage//60x60/{1}", _UriPfad, name));
            // return new PvImage(string.Format("http://pvlivedigitalbilder.pvkompass.de/KompassImage//60x60/{0}", name));
            //return new PvImage(string.Format("http://pvbinarysystem/Handler/GetKompassImage.ashx?filename={0}&bildformat=_60x60", name));

            //return new PvImage(string.Format("http://www.pvkompass.de/Handler/ImageView.ashx?path1={0}&width=60&height=60&png=0&preserve=1", name));
            //return new PvImage(String.Format("pvimg://Empty/"));
        }

        public PvImage(Uri imageUri)
        {
            _ImageUri = imageUri;
        }

        public PvImage(String imageUriString)
        {
            if (!Uri.TryCreate(imageUriString, UriKind.RelativeOrAbsolute, out _ImageUri))
            {
                _IsFaulted = true;
            }
        }


        [DataMember]
        private Uri _ImageUri;

        [DataMember]
        private Boolean _IsFaulted;


        public bool LargeImageLoaded { get; set; }


        /// <summary>
        /// Liefert den BildURI-String
        /// </summary>
        public Uri ImageURI
        {
            get
            {
                return _ImageUri;
            }
        }

        public Boolean IsFaulted
        {
            get
            {
                return _IsFaulted;
            }
        }

        #region INotifyPropertyChanged Member

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string _name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_name));
            }
        }

        #endregion

        public override string ToString()
        {
            return ImageURI.AbsoluteUri;
        }
    }
}
