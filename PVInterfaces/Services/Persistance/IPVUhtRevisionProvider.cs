/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       UhtRevision 
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die UhtRevision erfüllen muss
 *********************************************************************************************************/

using PV.DomainObjects;
using PVInterfaces.Enums;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die UhtRevision erfüllen muss
    /// </summary>
    public interface IPVUhtRevisionProvider
    {
        /// <summary>
        /// Liefert die letzte Verion der UhtRevisionen
        /// </summary>
        /// <returns>Die letzte UhtRevision</returns>
        UhtRevision GetLatestVersion();

        /// <summary>
        /// Sichert eine UhtRevision in die Datenbank
        /// </summary>
        /// <param name="_uhtRevision">Die zu sichernde UhtRevision</param>
        /// <returns>Information über das Speicherergebnis in Form eines SaveResults</returns>
        SaveResults AddVersion( UhtRevision _uhtRevision );

        /// <summary>
        /// Setzt eine UhtRevision mit einer bestimmten Version in der Datenbank auf commited
        /// </summary>
        /// <param name="_version">Die Version welche auch Commited gesetzt werden soll</param>
        /// <returns>Information über das Speicherergebnis in Form eines SaveResults</returns>
        SaveResults SetVersionCommited( int _version );

        /// <summary>
        /// Liefert die Information ob eine UhtRevision mit einer bestimmten Version bereits Commited wurde
        /// </summary>
        /// <param name="_version">Die Version für welche Commited geprüft werten soll werden soll</param>
        /// <returns>true, wenn die Version der UhtRevision Commited ist</returns>
        bool VersionCommited( int _version );
    }
}
