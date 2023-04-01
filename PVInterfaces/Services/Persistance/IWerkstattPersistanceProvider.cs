/***********************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Wekstattverwaltung
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Werkstätten erfüllen muss
 ***********************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.Stammdaten;
using PVInterfaces.Enums;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für Werkstätten erfüllen muss
    /// </summary>
    
    public interface IWerkstattPersistanceProvider
    {

        
        Version GetVersion();

        /// <summary>
        /// Liefert die Werkstatt
        /// In dieser Version des Programms wird esn nur eine Werkstatt geben
        /// In dieser Methode werden nur die Werkstatt und Ihre Profile geladen
        /// </summary>
        /// <returns>Die in der DB gespeicherte Werkstatt</returns>
        
        Werkstatt GetWerkstattSimple();

        /// <summary>
        /// Liefert für eine Werkstatt die selektierten Hersteller
        /// </summary>
        /// <param name="_werkstattId">Die GUID der Werkstatt für welche die Hersteller angefragt werden</param>
        /// <returns>Liste von Herstellern</returns>
        
        List<Hersteller> GetSelectedHersteller(Guid _werkstattId);

        /// <summary>
        /// Liefert für eine Werkstatt die ArbeitswertArten
        /// </summary>
        /// <param name="_werkstattId">Die GUID der Werkstatt für welche die ArbeitswertArten angefragt werden</param>
        /// <returns>Liste von ArbeitswertArt-Objekten</returns>
        
        List<ArbeitswertArt> GetArbeitswertarten(Guid _werkstattId);

        /// <summary>
        /// Liefert für eine Werkstatt die DokumentDruckOptionen
        /// </summary>
        /// <param name="_werkstattId">Die GUID der Werkstatt für welche die DokumentDruckOptionen angefragt werden</param>
        /// <returns>Liste von DokumentDruckOption-Objekten</returns>
        
        List<DokumentDruckOption> GetDruckoptionen(Guid _werkstattId);

        /// <summary>
        /// Sichert die übergebene Werkstatt in der DB
        /// </summary>
        /// <param name="_werkstatt">Die zu sichernde Werkstatt</param>
        /// <returns>Das Speicherergebnis in Form eines SaveResults</returns>
        
        SaveResults SaveWerkstatt( Werkstatt _werkstatt );

        /// <summary>
        /// Sichert eine übergebe DokumentDruckOption
        /// </summary>
        /// <param name="_dokumentDruckOption">Die DokumentDruckOption welche gespeichert werden soll</param>
        /// <param name="_werkstatt">Die Werkstatt zu welcher die DokumentDruckOption gehört</param>
        /// <returns>Das Speicherergebnis</returns>
        
        SaveResults SaveDokumentDruckOption( DokumentDruckOption _dokumentDruckOption, Werkstatt _werkstatt );

        /// <summary>
        /// Liefert eine Liste aller Mitarbeiter der Werkstatt
        /// </summary>
        /// <returns>Liste aller Mitarbeiter</returns>
        
        List<Mitarbeiter> LoadMitarbeiterListe();

        /// <summary>
        /// Liefert die Info ob ein Username unter einer Guid existiert 
        /// </summary>
        /// <returns>True, wenn der Username nicht existiert oder die Guid zum Namen gehört</returns>
        
        bool UserNameIsPossible(string _username, Guid _id);

        /// <summary>
        /// Sichert einen übergeben Mitarbeiter
        /// </summary>
        /// <param name="_mitarbeiter">Der zu sichernde Werkstatt</param>
        /// <returns>Das Speicherergebnis in Form eines SaveResults</returns>
        
        SaveResults SaveMitarbeiter( Mitarbeiter _mitarbeiter );

        /// <summary>
        /// Löscht einen übergeben Mitarbeiter
        /// </summary>
        /// <param name="_mitarbeiterId">Die Guid des zu löschenden Mitarbeiters</param>
        /// <returns>Das Ergebnis des Löschens in Form eines SaveResults</returns>
        
        SaveResults DeleteMitarbeiter( Guid _mitarbeiterId );

        /// <summary>
        /// Liest eine Konfiguration als Key-Value Wert.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        
        string GetKonfig(string key);

        /// <summary>
        /// Schreibt eine Konfiguration als Key-Value Wert.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        
        void SetKonfig(string key, string value);

        /// <summary>
        /// Muss vom Client in Intervallen kleibner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();
    }
}
