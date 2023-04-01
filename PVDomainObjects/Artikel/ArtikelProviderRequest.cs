using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PV.DomainObjects.Common;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public class ArtikelProviderRequest<T> : IArtikelProviderRequest where T : class
    {
        public ArtikelProviderRequest(Int32 absatzgruppe, Int32 kundengruppe, Int32 firma, Int32 standort, Int32 abteilung, Boolean isPlusKunde,
            Boolean isPitStop, T innerRequest, Int32 versandadresse, Int32 kundennummer, Boolean isHandelspartner, bool isStartseitenartikelsuche, string alternativeCSO)
        {
            Debug.Assert((typeof(T).GetCustomAttributes(typeof(DataContractAttribute),false) != null),"ArtikelProviderRequest. Der generische Typ muss einen DataContract bereitstellen!");

            _Absatzgruppe = absatzgruppe;
            _Kundengruppe = kundengruppe;
            _Firma = firma;
            _Standort = standort;
            _Abteilung = abteilung;
            _IsPlusKunde = isPlusKunde;
            _IsPitStop = isPitStop;
            _Kundenummer = kundennummer;
            _Versandadresse = Versandadresse;
            _InnerRequest = innerRequest;
            _IsHandelspartner = isHandelspartner;
            _IsStartseitenartikelsuche = isStartseitenartikelsuche;
            _AlternativeCSO = alternativeCSO;
            //_IsPraesentationsModus = isPraesentationsModus;
        }


        // Der Konstruktor hier wird von den Skripten benutzt und darf nicht geändert oder entfernt werden.
        public ArtikelProviderRequest(Int32 absatzgruppe, Int32 kundengruppe, Int32 firma, Int32 standort, Int32 abteilung, Boolean isPlusKunde, Boolean isPitStop, T innerRequest, Int32 versandadresse, Int32 kundennummer, Boolean isHandelspartner, bool isStartseitenartikelsuche)
        {
            Debug.Assert((typeof(T).GetCustomAttributes(typeof(DataContractAttribute), false) != null), "ArtikelProviderRequest. Der generische Typ muss einen DataContract bereitstellen!");

            _Absatzgruppe = absatzgruppe;
            _Kundengruppe = kundengruppe;
            _Firma = firma;
            _Standort = standort;
            _Abteilung = abteilung;
            _IsPlusKunde = isPlusKunde;
            _IsPitStop = isPitStop;
            _Kundenummer = kundennummer;
            _Versandadresse = Versandadresse;
            _InnerRequest = innerRequest;
            _IsHandelspartner = isHandelspartner;
            _IsStartseitenartikelsuche = isStartseitenartikelsuche;
            _AlternativeCSO = "";
            //_IsPraesentationsModus = isPraesentationsModus;
        }


        [DataMember] 
        private T _InnerRequest;

        [DataMember]
        private List<int> _Konzeptkennzeichen;

        [DataMember]
        private Int32 _Absatzgruppe;
        [DataMember]
        private Int32 _Kundengruppe;

        [DataMember] 
        private Int32? _profilId;
        [DataMember]
        private Int32 _Firma;
        [DataMember]
        private Int32 _Standort;
        [DataMember]
        private Int32 _Abteilung;
        [DataMember]
        private Int32 _Kundenummer;
        [DataMember]
        private Int32 _Versandadresse;
       
        [DataMember]
        private Boolean _IsPitStop;

        [DataMember]
        private Boolean _IsPlusKunde;

        [DataMember]
        private Boolean _IsHandelspartner;

        [DataMember]
        private Boolean _IsPraesentationsModus;

        [DataMember]
        private Boolean _IsStahlgruberAbfrage;

        [DataMember]
        private bool _IsStartseitenartikelsuche { get; set; }

        [DataMember]
        private string _AlternativeCSO { get; set; }

        public T InnerRequest
        {
            get { return _InnerRequest; }
            set { _InnerRequest = value; }
        }

        public bool IsStartseitenartikelsuche
        {
            get { return _IsStartseitenartikelsuche; }
        }

        public Int32? ProfilId
        {
            get { return _profilId; }
            set { _profilId = value; }
        }

        public Int32 Absatzgruppe
        {
            get { return _Absatzgruppe; }
        }
        public Int32 Kundengruppe
        {
            get { return _Kundengruppe; }
        }

        public Int32 Versandadresse
        {
            get { return _Versandadresse; }
        }

        public Int32 Kundenummer
        {
            get { return _Kundenummer; }
        }

        public List<int> Konzeptkennzeichen
        {
            get { return _Konzeptkennzeichen; }
            set { _Konzeptkennzeichen = value;  }
        }

        public Int32 Firma
        {
            get { return _Firma; }
        }

        public string AlternativeCSO
        {
            get { return _AlternativeCSO; }
            set { _AlternativeCSO = value; }
        }

        public Int32 Standort
        {
            get { return _Standort; }
        }
        public Int32 Abteilung
        {
            get { return _Abteilung; }
        }

        public Boolean IsPlusKunde
        {
            get { return _IsPlusKunde; }
        }

        public Boolean IsPitStop
        {
            get { return _IsPitStop; }
        }

        public Boolean IsHandelspartner
        {
            get { return _IsHandelspartner; }
        }
        
        public Boolean IsStahlgruberAbfrage
        {
            get { return _IsStahlgruberAbfrage; }
            set { _IsStahlgruberAbfrage = value; }
        }

        public Boolean IsPraesentationsModus
        {
            get { return _IsPraesentationsModus; }
            set { _IsPraesentationsModus = value; }
        }

        public override string ToString()
        {
            //return base.ToString();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Absatzgruppe: " + Absatzgruppe.ToString());
            sb.AppendLine("Kundengruppe: " + Kundengruppe.ToString());
            sb.AppendLine("Firma: " + Firma.ToString());
            sb.AppendLine("Standort: " + Standort.ToString());
            sb.AppendLine("Abteilung: " + Abteilung.ToString());
            sb.AppendLine("Kundenummer: " + Kundenummer.ToString());
            sb.AppendLine("Versandadresse: " + Versandadresse.ToString());
            sb.AppendLine("IsPlusKunde: " + IsPlusKunde.ToString());
            sb.Append(_InnerRequest.ToString());
            return sb.ToString();
        }

        public string fsaString
        {
            get
            {
                return string.Format("{0:000}.{1:000}.{2:000}", Firma, Standort, Abteilung);
            }
        }
    }
}
