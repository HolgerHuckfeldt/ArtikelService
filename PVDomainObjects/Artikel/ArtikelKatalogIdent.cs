/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Walter Licht
 * Modul:    Artikel-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Artikels
 ***********************************************************************************/

using System;
using System.Runtime.Serialization;
using System.Text;
using System.Collections.Generic;

namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    [KnownType(typeof(Artikel))]
    public class ArtikelKatalogIdent : PVDomainObjectBase
    {

        public ArtikelKatalogIdent()
        {

        }

        //public ArtikelKatalogIdent(SerializationInfo info, StreamingContext ctxt)
        //{

        //}

        public ArtikelKatalogIdent ToArtikelKatalogIdent()
        {
            return  new ArtikelKatalogIdent()
            {
                ArtikelNummer = ArtikelNummer,
                DatenlieferantenNummer = DatenlieferantenNummer,
                GenArtNr = GenArtNr,
                LfdNr = LfdNr,
                XTypArt = XTypArt,
                XTypNr = XTypNr,
                VehicleId = VehicleId,
                ArtikelId = ArtikelId,
                Art = Art,

            };
        }

        /// <summary>
        /// Liefert und setzt die Laufende Nummer in der xTyp-GenArt-Artikel Beziehung
        /// </summary>
        [DataMember]
        public virtual Int32? LfdNr
        {
            get;
            set;
        }

        [DataMember]
        public virtual GebrauchsmusterArt? XTypArt
        {
            get;
            set;
        }

        [DataMember]
        public virtual Int32? XTypNr
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt Artikelnummer
        /// </summary>
        [DataMember]
        public virtual string ArtikelNummer
        {
            get;
            set;
        }
        
        /// <summary>
        /// Liefert und setzt TecDoc AlternativeArtikelliste
        /// </summary>
        public List<Artikel> AlternativeArtikellisteTecDoc
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die DatenlieferantenNummer
        /// </summary>
        [DataMember]
        public virtual Int64 DatenlieferantenNummer
        {
            get;
            set;
        }

        [DataMember]
        public virtual Int64 HerstellerNummer
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Nummer des Generischen ARtikels
        /// </summary>
        [DataMember]
        public virtual int GenArtNr
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Nummer des Generischen ARtikels
        /// </summary>
        [DataMember]
        public virtual int GenArtNrTecDoc
        {
            get;
            set;
        }

        [DataMember]
        public int? VehicleId { get; set; }
        
        [DataMember]
        public int ArtikelId { get; set; }

        /// <summary>
        /// Artikelart, z.B. PKW Artikel
        /// </summary>
        [DataMember]
        public ArtikelArt Art { get; set; }

        /// <summary>
        /// FahrzeugTyp-Id wird z.B. für verwandte Artikel gebraucht
        /// </summary>
        [DataMember]
        public int? Typ { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Artikelnummer: " + ArtikelNummer);
            sb.AppendLine("Datenlieferantennummer: " + DatenlieferantenNummer.ToString());
            sb.AppendLine("GenArtNr: " + GenArtNr.ToString());
            return sb.ToString();
        }

        #region ISerializable Member

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
