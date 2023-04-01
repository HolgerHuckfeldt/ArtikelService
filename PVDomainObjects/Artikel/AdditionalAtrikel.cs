/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikel-Identifikation   
 * Funktionen: Kapselt die Informationen und Funktionen eines zusätzlichen Artikels
 ***********************************************************************************/

using System;

namespace PV.DomainObjects.Artikel
{
    /// <summary>
    /// Erweitert den Artikel um die Informationen eines zusätzlichen Artikels
    /// </summary>
    [Serializable] 
    public class AdditionalAtrikel : Artikel
    {
        #region Fields

        private string _GruppenBezeichnung;
        private int _GruppenBezeichnungId;
        
        #endregion

        #region AdditionalArtikel Member

        /// <summary>
        /// Liefert und setzt die Gruppenbezeiuchnung
        /// </summary>
        public string GruppenBezeichnung
        {
            get
            {
                return _GruppenBezeichnung != null ? _GruppenBezeichnung.Trim() : string.Empty;
            }
            set
            {
                _GruppenBezeichnung = value;
            }
        }

        /// <summary>
        /// Liefert und setzt die GruppenID
        /// </summary>
        public int GruppenBezeichnungId
        {
            get
            {
                return _GruppenBezeichnungId;
            }
            set
            {
                _GruppenBezeichnungId = value;
            }
        }

        #endregion
    }
}
