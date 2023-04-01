/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    Artikelsuche
* Funktionen: Abstrahiert die Schnittstelle des Benutzermanagers für das Login
*             NICHT VERWECHSELN MIT STAMMDATEN!!!
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Stammdaten;
using PV.DomainObjects.Warenkorb;
using PVInterfaces.Enums;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Businesslayers zum Frontend bezüglich der Benutzerdaten
    /// </summary>
    public interface IBenutzerManager
    {
        /// <summary>
        /// Liefert den derzeit eingeloggten User
        /// </summary>
        Mitarbeiter CurrentUser
        {
            get;
        }

        /// <summary>
        /// Liefert den User welcher sein PW resetten wollte
        /// </summary>
        Mitarbeiter PWResetUser
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert Loggt einen User anhand seines Usernamens und seines Passwortes ein
        /// </summary>
        /// <param name="_username">Der Loginnname</param>
        /// <param name="_passwort">Das Passwort</param>
        /// <param name="_save">Gibt an ob die Daten gespeichert werden sollen</param>
        /// <returns>true, wenn des User eingeloggt werden konnte</returns>
        bool Login( string _username, string _passwort, bool _save );

        /// <summary>
        /// Loggt den CirrentUser aus
        /// </summary>
        /// <returns>true, wenn das Logout erfolgreich war</returns>
        bool Logout();

        /// <summary>
        /// Setzt das Passwort eines User anhand seines Usernamens zurück
        /// </summary>
        /// <param name="_username">Der Username</param>
        /// <param name="_pw">Ein zu verwendenses Passport/null erzeugt ein neues</param>
        /// <returns>Die Mailadresse an welche das neue PW gesendet wurde, null wenn keine Mail versendet werden konnte</returns>
        SaveResults ResetPassword(string _username, string _pw);

        /// <summary>
        /// Liest den aktuellen User neu aus der DB ein
        /// </summary>
        void RefreshCurrentUser();

        /// <summary>
        /// Gibt das Identifizierungstupel für VDB Calls zurück
        /// </summary>
        /// <returns>Ein VdbUserInfo-Objekt mit Identdaten für die VDB</returns>
        VdbUserInfo GetVdbUserInfo();

        /// <summary>
        /// Liefert eine Liste von Nutzernamen
        /// </summary>
        /// <returns>Liste mit Usernamen als String</returns>
        IList<string> GetUsernameList();

        /// <summary>
        /// Liefert den Username des zuletzt eingelogten Users
        /// </summary>
        /// <returns>Der Username</returns>
        string GetLastUserName();

        /// <summary>
        /// Liefert zu einem Usernamen, das lokal gespeicherte Passwort (Cookie-Imitation)
        /// </summary>
        /// <param name="_username">Der Username des Nutzers für welchen ein Passwort benötigt wird</param>
        /// <returns>Das Passwort, wenn es lokal gespeichert wurde, sonst null</returns>
        string GetPasswordForUser(string _username);
    }
}
