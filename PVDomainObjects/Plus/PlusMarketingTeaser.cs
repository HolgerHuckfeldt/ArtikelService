using System;
using System.ComponentModel;
using PV.DomainObjects.Stammdaten;
using GlobalEnums;
using EKonzeptkennzeichen = GlobalEnums.EKonzeptkennzeichen;

namespace PV.DomainObjects.Plus
{
    [Serializable]
    public class PlusMarketingTeaser : Artikel.Artikel
    {

        #region Fields

        private string _bildUrl;
        private string _textUrl;
        private string _deepLink;
        private EKonzeptkennzeichen _konzeptKennzeichen;

        #endregion

        #region Properties

        public string BildUrl
        {
            get { return _bildUrl; }
            set { _bildUrl = value; }
        }

        public string TextUrl
        {
            get { return _textUrl; }
            set { _textUrl = value; }
        }

        public string DeepLink
        {
            get { return _deepLink; }
            set { _deepLink = value; }
        }

        public EKonzeptkennzeichen KonzeptKennzeichen
        {
            get { return _konzeptKennzeichen; }
            set { _konzeptKennzeichen = value; }
        }

        #endregion

        public PlusMarketingTeaser(string bildUrl, string textUrl, string deepLink, EKonzeptkennzeichen konzeptKennzeichen)
        {
            BildUrl = bildUrl;
            TextUrl = textUrl;
            DeepLink = deepLink;
            KonzeptKennzeichen = konzeptKennzeichen;
        }

    }
}
