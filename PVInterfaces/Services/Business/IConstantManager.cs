/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       Stammdatenverwaltung 
 * Funktionen:  Abstrahiert die Schnittstelle des Managers für unveränderliche Konstanten
 *********************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjects.Common;
using PV.DomainObjects.Kunden;
using PV.DomainObjects.Stammdaten;
using PV.Utilities.Interfaces;

namespace PV.Business.Services
{

    /// <summary>
    /// Abstrahiert die Schnittstelle des Managers für unveränderliche Konstanten
    /// </summary>
    public interface IConstantManager
    {
        #region allgemeine Infos

        /// <summary>
        /// Liste der Umsatzsteuer Arten
        /// </summary>
        List<UStArt> UstArten
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der Einheiten
        /// </summary>
        IList<Einheit> Einheiten
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der Anreden
        /// </summary>
        IList<Anrede> Anreden
        {
            get;
        }

        #endregion
    }
}
