using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Plus
{
    public class Lieferadresse
    {
        private string _empfaenger;

        private string _empfaengerZusatz;

        private string _adressZusatz;

        private string _strasse;

        private string _plz;

        private string _ort;

        public string Empfaenger
        {
            get
            {
                return _empfaenger;
            }
            set
            {
                _empfaenger = value;
            }
        }

        public string EmpfaengerZusatz
        {
            get
            {
                return _empfaengerZusatz;
            }
            set
            {
                _empfaengerZusatz = value;
            }
        }

        public string AdressZusatz
        {
            get
            {
                return _adressZusatz;
            }
            set
            {
                _adressZusatz = value;
            }
        }

        public string Strasse
        {
            get
            {
                return _strasse;
            }
            set
            {
                _strasse = value;
            }
        }

        public string Plz
        {
            get
            {
                return _plz;
            }
            set
            {
                _plz = value;
            }
        }

        public string Ort
        {
            get
            {
                return _ort;
            }
            set
            {
                _ort = value;
            }
        }
    }
}
