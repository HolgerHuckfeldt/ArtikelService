/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Torsten Gaul
 * Modul:    DomainObjects   
 * Funktionen: Kapselt die Informationen und Funktionen der Eigenen Artikel
 *************************************************************************/

using System;
using PV.DomainObjectInterfaces;
using PV.DomainObjects.Common;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace PV.DomainObjects.Stammdaten
{
    /// <summary>
    /// Kapselt die Informationen und Funktionen der Eigenen Artikel
    /// </summary>
    [Serializable]

    [KnownType(typeof(Einheit))]
    [KnownType(typeof(UStArt))]
    [KnownType(typeof(Werkstatt))]
    public class EigenerArtikel : IEquatable<EigenerArtikel>, IKVAItem, ISerializable
    {

        #region fields

        private string _Hersteller = string.Empty;

        private string _HerstellerArtikelNummer = string.Empty;

        private string _Bezeichnung = string.Empty;

        private string _Beschreibung = string.Empty;

        private string _EAN = string.Empty;

        #endregion

        public EigenerArtikel()
        {
            Id = Guid.NewGuid();
        }


        public EigenerArtikel(SerializationInfo info, StreamingContext ctxt)
        {
            // Hier deserialisieren...

            var values = info.GetEnumerator();

            while (values.MoveNext())
            {

                switch (values.Name)
                {
                    case "Bezeichnung":
                        if (values.Value != null)
                            Bezeichnung = values.Value as string;
                        break;

                    case "_Hersteller":
                        if (values.Value != null)
                            _Hersteller = values.Value as string;
                        break;
                    case "_HerstellerArtikelNummer":
                        if (values.Value != null)
                            _HerstellerArtikelNummer = values.Value as string;
                        break;
                    case "_Beschreibung":
                    case "Beschreibung":
                        if (values.Value != null)
                            Beschreibung = values.Value as string;
                        break;
                    case "_EAN":
                        if (values.Value != null)
                            _EAN = values.Value as string;
                        break;
                    case "Id":
                        if (values.Value != null)
                            Id = (Guid)values.Value;
                        break;
                    case "ArtikelNummer":
                        if (values.Value != null)
                            ArtikelNummer = (long)values.Value;
                        break;
                    case "VerpackungsEinheit":
                        if (values.Value != null)
                            VerpackungsEinheit = (int)values.Value;
                        break;
                    case "VerpackungsEinheitF":
                        if (values.Value != null)
                            VerpackungsEinheitF = (float)values.Value;
                        break;
                    case "IsKvaArtikel":
                        if (values.Value != null)
                            IsKvaArtikel = (bool)values.Value;
                        break;
                    case "ArtikelEinheit":
                        if (values.Value != null)
                            ArtikelEinheit = (Einheit)values.Value;
                        break;
                    case "Umsatzsteuer":
                        if (values.Value != null)
                            Umsatzsteuer = (UStArt)values.Value;
                        break;
                    case "RegelSteuersatz":
                        if (values.Value != null)
                            RegelSteuersatz = (double)values.Value;
                        break;
                    case "VKBrutto":
                        if (values.Value != null)
                        {
                            VKBrutto = (double)values.Value;
                        }
                            //VKBrutto = (double)values.Value;
                        break;
                    case "VKNetto":
                        if (values.Value != null)
                            VKNetto = (double)values.Value;
                        break;
                    case "EKNetto":
                        if (values.Value != null)
                            EKNetto = (double)values.Value;
                        break;
                    case "Werkstatt":
                        if (values.Value != null)
                            Werkstatt = values.Value as Werkstatt;
                        break;



                    default:
                        Console.WriteLine("Unbekanntes Attribute:" + values.Name);
                        break;
                }
            }          

        }


        #region Props

        /// <summary>
        /// Setzt und Liefert die Nummer in der DB
        /// </summary>

        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// Die ArtikelNummer numerisch max 10 Zeichen
        /// </summary>

        public long ArtikelNummer
        {
            get;
            set;
        }

        /// <summary>
        /// Hersteller des Eigenen Artikels
        /// </summary>

        public string Hersteller
        {
            get
            {
                return _Hersteller;
            }
            set
            {
                _Hersteller = value;
            }
        }
        /// <summary>
        /// Die vom Hersteller vergebene Artikelnummer
        /// </summary>

        public string HerstellerArtikelNummer
        {
            get
            {
                return _HerstellerArtikelNummer;
            }
            set
            {
                _HerstellerArtikelNummer = value;
            }
        }

        /// <summary>
        /// Bezeichnung des Eigenen Artikels 
        /// </summary>

        public string Bezeichnung
        {
            get
            {
                return _Bezeichnung;
            }
            set
            {
                _Bezeichnung = value;
            }
        }

        /// <summary>
        /// Beschreibung des Eigenen Artikels
        /// </summary>

        public string Beschreibung
        {
            get
            {
                return _Beschreibung;
            }
            set
            {
                _Beschreibung = value;
            }
        }

        /// <summary>
        /// Die Verpackungseinheit des Eigenen Artikels (1 to N)
        /// </summary>

        public int VerpackungsEinheit
        {
            get;
            set;
        }

        /// <summary>
        /// Die Verpackungseinheit des Eigenen Artikels (1.x to N.x)
        /// </summary>
        public float VerpackungsEinheitF
        {
            get;
            set;
        }

        /// <summary>
        /// Ist der Artikel im KVA?
        /// </summary>
        public bool IsKvaArtikel
        {
            get; 
            set;
        }

        /// <summary>
        /// European Article Number ( 8 OR 13 digits)
        /// </summary>

        public string EAN
        {
            get
            {
                return _EAN;
            }
            set
            {
                _EAN = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die Artikeleinheit
        /// </summary>

        public Einheit ArtikelEinheit
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Nettoeinkaufspreis
        /// </summary>

        public double EKNetto
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den Nettoverkaufspreis
        /// </summary>
        public double VKNetto
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Umsatzsteuerart
        /// </summary>

        public UStArt Umsatzsteuer
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den aktuellen Regelsteuerstz
        /// </summary>

        public double RegelSteuersatz
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den VKPreis
        /// </summary>
        public double VKBrutto
        {
            get;
            set;
        }

        /// <summary>
        /// Die Werkstatt, welche den eigenen Artikel erstellt hat
        /// </summary>
        public Werkstatt Werkstatt
        {
            get;
            set;
        }

        #endregion

        #region IEquatable<EigenerArtikel> Member

        public bool Equals(EigenerArtikel other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            EigenerArtikel toCompare = obj as EigenerArtikel;
            if (toCompare != null)
                return toCompare.Id == Id;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion

        #region ISerializable Member

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bezeichnung", Bezeichnung);
            info.AddValue("Beschreibung", Beschreibung);

            info.AddValue("_Hersteller", _Hersteller);
            info.AddValue("_HerstellerArtikelNummer", _HerstellerArtikelNummer);
            info.AddValue("_Beschreibung", _Beschreibung);
            info.AddValue("_EAN", _EAN);
            info.AddValue("Id", Id);
            info.AddValue("ArtikelNummer", ArtikelNummer);
            info.AddValue("VerpackungsEinheit", VerpackungsEinheit);
            info.AddValue("VerpackungsEinheitF", VerpackungsEinheitF);
            info.AddValue("IsKvaArtikel", IsKvaArtikel);
            info.AddValue("ArtikelEinheit", ArtikelEinheit);
            info.AddValue("Umsatzsteuer", Umsatzsteuer);
            info.AddValue("RegelSteuersatz", RegelSteuersatz);
            info.AddValue("VKBrutto", VKBrutto);
            info.AddValue("VKNetto", VKNetto);
            info.AddValue("EKNetto", EKNetto);
            info.AddValue("Werkstatt", Werkstatt);
        }

        #endregion
    }
}