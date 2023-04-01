/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Fahrzeugidentifikation
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für den ProfileValidierung erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.Stammdaten;
using GlobalEnums;
using PV.DomainObjects.Statistic;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für den ProfileValidierung erfüllen muss
    /// </summary>

    
    public interface IPVProfilProvider
    {
        /// <summary>
        /// Beim Start von Kompass wird die aktuelle PV:Manager-Version und der Zeitpunkt der Werkstatt für jedes verwendete Profil gespeichert
        /// </summary>
        /// <param name="_profil">daten der Aktuelle Manager Version</param>
        /// <returns>true (erfolgreich gespeichert) or false (sonst) </returns>
        
        String AktuelleManagerVersionSpeichern(ManagerVersion _aktuelleManagerVersion);

        /// <summary>
        /// Beim Start von Kompass wird die aktuelle Kompassversion und der Zeitpunkt der Werkstatt für jedes verwendete Profil gespeichert
        /// </summary>
        /// <param name="_profil">daten der AktuelleKompassVersion</param>
        /// <returns>true (erfolgreich gespeichert) or false (sonst) </returns>
        
        String AktuelleKompassVersionSpeichern(List<AktuelleKompassVersion> _aktuelleKompassVersion);

        /// <summary>
        /// Validiert ein übergebenes Profil und füllt dieses
        /// </summary>
        /// <param name="_profil">Das zu validierende Profil</param>
        /// <returns>Das valiedierte Profil</returns>
        
        Profil ValidateProfile(Profil _profil, bool StahlgruberPitStop);

        
        bool SaveMeinSortiment(int _profilId, List<MyArtikelKategorien> meinSortiment);

        
        bool HybridKKZnichtmehrgueltig(int _profilId);

        /// <summary>
        /// Validiert die Profile einer Werkstatt
        /// </summary>
        /// <param name="_werkstatt">Die zu validierende Werkstatt</param>
        /// <returns>Die valiedierte Werkstatt</returns>
        
        Werkstatt ValidateWerkstatt(Werkstatt _werkstatt, bool StahlgruberPitStop);

        /// <summary>
        /// Sichert ein Profil einer Werkstatt
        /// </summary>
        /// <param name="_profil">Das zu sichernde Profil</param>
        /// <param name="_activate">gibt an ob es sich um eine Aktivierung oder einen Editiervorgang handelt.</param>
        /// <returns>true, wenn fehlerfrei gesichert werden konnte</returns>
        
        bool SaveProfil(Profil _profil, bool _activate);

        /// <summary>
        /// Gibt die trainingsrelevanten Konzeptkennzeichen zurück
        /// </summary>
        
        IList<DomainObjects.Stammdaten.EKonzeptkennzeichen> GetKonzeptKennzeichen(Profil _profil);

        /// <summary>
        /// Gibt die Anzahl der Freien Trainingstage für eine Liste trainingsrelvanter Konzepzkennzeichen zurück.
        /// </summary>
        
        int GetAnzahlFreieTrainingsTage(IList<DomainObjects.Stammdaten.EKonzeptkennzeichen> _kkzListe, Profil _profil);

        
        void SendDvseAuth(string token, int profile, string ip);

        
        void SendAuthToken(string token, int profile, string ip, string destName);

        
        string GetExtraInfo(int profileId, string key);

        
        List<ExtraProfilValue> GetAllExtraInfo(int profileId, List<ExtraProfilValue> extraProfilValues);

        
        void SetAllExtraInfo(int profileId, List<ExtraProfilValue> extraProfilValues);

        
        void SetExtraInfo(int profileId, string key, string value);

        
        void UploadStat(List<StatisticEntry> stats, int profileId, string plz);

    }
}
