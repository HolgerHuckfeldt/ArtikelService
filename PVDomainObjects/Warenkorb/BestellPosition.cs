using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using PV.DomainObjects.Artikel;

namespace PV.DomainObjects.Warenkorb
{
    class BestellPosition : IPosition
    {
        public delegate void StatusflagChangedHandler();

        public event StatusflagChangedHandler StatusflagChanged;

        private void OnStatusflagChanged()
        {
            if (StatusflagChanged != null)
            {
                StatusflagChanged();
            }
        }

        private Artikel.Artikel _Ware;
        private int _Menge;
        private int _Verfuegbarkeit;
        private int _Statusflag;
        private int _VDBStatus;
        private string _Txt1 = String.Empty;
        private string _Txt2 = String.Empty;
        private Guid _GuidKompass;
        private int _PosNummer;

        public Artikel.Artikel Ware
        {
            get
            {
                return _Ware;
            }
            set
            {
                _Ware = value;
            }
        }

        public int Menge
        {
            get
            {
                return _Menge;
            }
            set
            {
                _Menge = value;
            }
        }

        public int Verfuegbarkeit
        {
            get
            {
                return _Verfuegbarkeit;
            }
            set
            {
                _Verfuegbarkeit = value;
            }
        }

        public int Statusflag
        {
            get
            {
                return _Statusflag;
            }
            set
            {
                if (_Statusflag != value)
                {
                    _Statusflag = value;
                    OnStatusflagChanged();
                }
            }
        }

        public int VDBStatus
        {
            get
            {
                return _VDBStatus;
            }
            set
            {
                _VDBStatus = value;
            }
        }

        public string Txt1
        {
            get
            {
                return _Txt1;
            }
            set
            {
                _Txt1 = value;
            }
        }

        public string Txt2
        {
            get
            {
                return _Txt2;
            }
            set
            {
                _Txt2 = value;
            }
        }

        public Guid GuidKompass
        {
            get
            {
                return _GuidKompass;
            }
            set
            {
                _GuidKompass = value;
            }
        }

        public int PosNummer
        {
            get
            {
                return _PosNummer;
            }
            set
            {
                _PosNummer = value;
            }
        }
    }
}
