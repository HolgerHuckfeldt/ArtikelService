/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Verwaltung
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Werkstattmanager zu erfüllen hat
 *              Dabei werden auch die Mitarbeiterdaten behandelt.
 *              Es handelt sich dabei NUR um die Daten der Mitarbeiter, welche in der Werstattverwaltung benötigt werden,
 *              NICHT um die vom Mitarbeiter selber zu verwaltenden Daten. Diese werden über den Mitarbeiterprovider geregelt.
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Stammdaten;
using PVInterfaces.Enums;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Werkstattmanager zu erfüllen hat
    /// </summary>
    public interface IWerkstattManager
    {
        /// <summary>
        /// Lädt die Werkstatt aus der Lokalen DB und validiert ihre Profile gegen PV
        /// </summary>
        bool InitWerkstatt();

        /// <summary>
        /// Liefert die aktuelle Werkstatt
        /// </summary>
        Werkstatt CurrentWerkstatt
        {
            get;
        }

        /// <summary>
        /// Setzt die CurrentWerkstatt auf eine leere Werkstatt
        /// </summary>
        void SetEmptyWerkstatt();

        /// <summary>
        /// Sichert die CurrentWerkstatt
        /// </summary>
        /// <param name="_activate">gibt an ob es sich um eine Aktivierung oder einen Editiervorgang handelt.</param>
        /// <returns>Das Speicherergebnis</returns>
        SaveResults SaveWerkstatt(bool _activate);

        /// <summary>
        /// Sichert eine übergebe DokumentDruckOption
        /// </summary>
        /// <param name="_dokumentDruckOption">Die DokumentDruckOption welche gespeichert werden soll</param>
        /// <returns>Das Speicherergebnis</returns>
        SaveResults SaveDokumentDruckOption(DokumentDruckOption _dokumentDruckOption);

        /// <summary>
        /// Liefert ein leeres Profil
        /// </summary>
        /// <returns>Ein leeres Profil</returns>
        Profil GetEmptyProfil();

        /// <summary>
        /// Validiert ein Profil
        /// </summary>
        /// <param name="_profil">Das zu validierende Profil</param>
        /// <returns>Das vildierte Profil</returns>
        Profil ValidateProfil(Profil _profil);

        /// <summary>
        /// Liefert eine Liste aller Mitarbeiter der Werkstatt
        /// </summary>
        IList<Mitarbeiter> Mitarbeiterliste
        {
            get;
        }

        /// <summary>
        /// Liefert einen neuen leeren Mitarbeiter
        /// </summary>
        /// <returns></returns>
        Mitarbeiter GetEmptyMitarbeiter();

        /// <summary>
        /// Liefert die Info ob ein Username unter einer Guid existiert 
        /// </summary>
        /// <returns>True, wenn der Username nicht existiert oder die Guid zum Namen gehört</returns>
        bool UserNameIsPossible(string _username, Guid _id);

        /// <summary>
        /// Sichert einen übergeben Mitarbeiter
        /// </summary>
        /// <param name="_mitarbeiter">Der zu sichernde Werkstatt</param>
        /// <returns>Das Speicherergebnis</returns>
        //Thomas: Bearbeitung des Tickets
        //[ Inhalt Ticket#: 1007471 ] PV Plus nach der Adresse änderung kommt der PV Kompass
        //-> Einfügung von SaveTabPVPlus
        SaveResults SaveMitarbeiter(Mitarbeiter _mitarbeiter, bool SaveTabPVPlus, bool mitarbeiterNeuLaden);

        /// <summary>
        /// Löscht einen übergeben Mitarbeiter
        /// </summary>
        /// <param name="_mitarbeiter">Der zu löschende Werkstatt</param>
        /// <returns>Das Speicherergebnis</returns>
        SaveResults DeleteMitarbeiter(Mitarbeiter _mitarbeiter);
    }
}
