/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       Mitarbeiterverwaltung 
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Persistierung der Mitarbeiter benötigt
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Stammdaten;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für die Persistierung der Mitarbeiter benötigt
    /// </summary>
    public interface IMitarbeiterPersistanceProvider
    {

        #region Mitarbeiter

        /// <summary>
        /// Liefert das Passwort eines Mitarbeiter anhand seines Usernames
        /// </summary>
        /// <param name="_username">Der Username</param>
        /// <returns>das Passwort</returns>
        
        string GetMitarbeiterPasswortByUsername(string _username);

        /// <summary>
        /// Liefert einen Mitarbeiter mit allen verfügbaren Daten anhand seines Usernames
        /// </summary>
        /// <param name="_username">Der Username</param>
        /// <returns>Der Mitarbeiter</returns>
        
        Mitarbeiter GetMitarbeiterCompleteByUsername(string _username);

        /// <summary>
        /// Liefert einen Mitarbeiter mit allen verfügbaren Daten anhand seines Usernames
        /// </summary>
        /// <param name="_username">Der Username</param>
        /// <param name="_countIdent">Anzahl der History-Einträge</param>
        /// <param name="_countSearch">Anzahl der History-Einträge</param> 
        /// <returns>Der Mitarbeiter</returns>
        
        Mitarbeiter GetMitarbeiterCompleteByUsernameNew(string _username, int _countIdent, int _countSearch );

        /// <summary>
        /// Liefert einen Mitarbeiter mit allen verfügbaren Daten anhand seiner ID
        /// </summary>
        /// <param name="_id">Die ID</param>
        /// <returns>Der Mitarbeiter</returns>
        
        Mitarbeiter GetMitarbeiterCompleteByID(Guid _id);

        /// <summary>
        /// Liefert einen Mitarbeiter mit allen verfügbaren Daten anhand seiner ID
        /// </summary>
        /// <param name="_id">Die ID</param>
        /// <param name="_countIdent">Anzahl der History-Einträge</param>
        /// <param name="_countSearch">Anzahl der History-Einträge</param> 
        /// <returns>Der Mitarbeiter</returns>
        
        Mitarbeiter GetMitarbeiterCompleteByIDNew(Guid _id, int _countIdent, int _countSearch);
        #endregion

        /// <summary>
        /// Muss vom Client in Intervallen kleiner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();
    }
}
