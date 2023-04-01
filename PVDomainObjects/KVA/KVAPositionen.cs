/***************************************************************************
 * Copyright Totale Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Benjamin Schützig/Dirk Lannatewitz
 * Modul:    KVA 
 * Funktionen:  Kapselt die Funktionen und Informationen einer KVAPosition
 ***************************************************************************/

using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Common;
using PV.DomainObjects.Stammdaten;
using System.Runtime.Serialization;

namespace PV.DomainObjects.KVA
{
    [DataContract]
    [Serializable]
    public enum KVAPositionsArten
    {
        [EnumMember]
        Artikel,
        [EnumMember]
        EigenerArtikel,
        [EnumMember]
        Arbeitswert,
        [EnumMember]
        EigenerArbeitswert,
        [EnumMember]
        Wartung
    }

    /// <summary>
    /// selt die Funktionen und Informationen einer KVAPosition
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(ShallowInnerItem))]
    [KnownType(typeof(ShallowInnerItem))]
    [KnownType(typeof(UStArt))]
    [KnownType(typeof(List<ArbeitswertArt>))]
    [KnownType(typeof(ArbeitswertArt))]
    [KnownType(typeof(List<UStArt>))]
    [KnownType(typeof(Arbeitsprozess))]
    [KnownType(typeof(KVAPositionsArten))]
    [KnownType(typeof(KVAWartungsPosition))]
    [KnownType(typeof(EigenerArtikel))]
    [KnownType(typeof(EigenerArbeitswert))]

    //[KnownType(typeof(Wartung.WartungsChecklisteItem[]))]
    //[KnownType(typeof(List<Wartung.WartungsChecklisteItem>))]
    //[DataContract]
    //[DataContract]
    public class KVAPosition 
    {
        #region fields

        [NonSerialized]
        //[DataMember]
        private List<UStArt> _uStArten;
        //[DataMember]
        private List<ArbeitswertArt> _arbeitswertarten;
        //[DataMember]
        private int _Position;
        //[DataMember]
        private string _identNummer;
        //[DataMember]
        private string _herstellerBezeichnung;
        //[DataMember]
        private string _bezeichnung;
        //[DataMember]
        private decimal _menge;
        //[DataMember]
        private string _mengenbezeichnung;
        //[DataMember]
        private ArbeitswertArt _arbeitswertArt;
        //[DataMember]
        private decimal _leistungsRabatTotal;
        //[DataMember]
        private decimal _leistungsRabatProzent;
        //[DataMember]
        private decimal _materialRabatTotal;
        //[DataMember]
        private decimal _materialRabatProzent;
        //[DataMember]
        private decimal _margeTotal;
        //[DataMember]
        private decimal _margeProzent;
        //[DataMember]
        private decimal _ekPreis;
        //[DataMember]
        private decimal _vkPreis;
        //[DataMember]
        private UStArt _selectedUStArt;
        private object _innerItem;
        //[DataMember]
        private bool _notInWarenkorb;
        [NonSerialized]
        private decimal _tmpRapatt;

        private int _getArtNr;

        #endregion

        public KVA KVA
        {
            get;
            private set;
        }

        public virtual int GenArtNr
        {
            get { return _getArtNr; }
            set { _getArtNr = value; }
        }

        /// <summary>
        /// Erzeugt eine Instanz der Klasse
        /// </summary>
        /// <param name="kva">Der KVA zu dem die Position gehört</param>
        /// <param name="innerItem"></param>
        public KVAPosition(KVA kva, object innerItem)
        {
   

        }


    }
}
