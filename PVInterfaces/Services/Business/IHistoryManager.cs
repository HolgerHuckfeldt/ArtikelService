/******************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Modulübergreifend
 * Funktionen:      Abstrahiert die Schnittstelle des History-Managers und definiert dessen Delegates
*****************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.History;
using PV.Utilities.Interfaces;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des History-Managers 
    /// </summary>
    public interface IHistoryManager
    {
        #region IdentHistory

        /// <summary>
        /// Fügt der FahrzeugauswahlHistory einen PKW hinzu
        /// </summary>
        /// <param name="_typ">Der Typ des Fahrzeuges</param>
        void AddPKW( PKWTyp _typ );

        /// <summary>
        /// Für diese FahrzeugauswahlHistory ein NKW abspeichern
        /// </summary>
        /// <param name="_typ">Der selektierte Typ</param>
        void AddNKW( NKWTyp _typ );

        /// <summary>
        /// Fügt der FahrzeugauswahlHistory einen Motor hinzu
        /// </summary>
        /// <param name="_typ">Der Typ des Motors</param>
        void AddMotor( Motor _typ );

        /// <summary>
        /// Für diese FahrzeugauswahlHistory eine Achse abspeichern
        /// </summary>
        /// <param name="_typ">Der Typ Achse</param>
        void AddAchse( Achse _typ );

        /// <summary>
        /// Liefert eine Liste aller Historyeinträge
        /// </summary>
        IList<HistoryEntry> IdentHistoryList
        {
            get;
        }


        /// <summary>
        /// Liefert eine Liste der Historyeinträge für heute
        /// </summary>
        IList<HistoryEntry> IdentHistoryListToday
        {
            get;
        }


        /// <summary>
        /// Liefert eine Liste der Historyeinträge für gestern
        /// </summary>
        IList<HistoryEntry> IdentHistoryListYesterday
        {
            get;
        }


        /// <summary>
        /// Liefert eine Liste der Historyeinträge älter als Gestern
        /// </summary>
        IList<HistoryEntry> IdentHistoryListOld
        {
            get;
        }

        /// <summary>
        /// Aktiviert den PKW, NKW, Motor oder die Achse, welche als Historyentry übergeben wurde
        /// </summary>
        /// <param name="_toSet">Das zu setzende Historyentry</param>
        void SetHistoryEntryActive( HistoryEntry _toSet );

        /// <summary>
        /// Liefert den in einem HistoryEntry verschlüsselten PKW, NKW, die Achse oder den Motor
        /// </summary>
        /// <param name="_toSet">Das HistoryEntry</param>
        /// <returns>PKW, NKW, Achse oder Motor als Object</returns>
        object GetTypByHistoryEntry( HistoryEntry _toSet );

        #endregion

        #region FreitextSuchHistorien

        /// <summary>
        /// Fügt einen String aus der PKW Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddPKWFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die PKWFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> PKWFreitextSuchHistoy
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der NKW Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddNKWFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die NKWFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> NKWFreitextSuchHistoy
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Achsen-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddAchsenFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die AchsenFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> AchsenFreitextSuchHistoy
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Motoren-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddMotorenFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die MotorenFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> MotorenFreitextSuchHistoy
        {
            get;
        }


        /// <summary>
        /// Fügt einen String aus der Kunden-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddKundenFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die KundenFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> KundenFreitextSuchHistory
        {
            get;
        }


        /// <summary>
        /// Fügt einen String aus der Kunden-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddEigeneArtikelFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die KundenFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> EigeneArtikelFreitextSuchHistory
        {
            get;
        }



        /// <summary>
        /// Fügt einen String aus der Kunden-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddEigeneAWFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die KundenFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> EigeneAWFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der KVA-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddKVAFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die KVAFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> KVAFreitextSuchHistory
        {
            get;
        }


        /// <summary>
        /// Fügt einen String aus der PKWArtikel-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddPKWArtikelFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die PKWArtikelFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> PKWArtikelFreitextSuchHistory
        {
            get;
        }


        /// <summary>
        /// Fügt einen String aus der PKWArtikel-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddNKWArtikelFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die PKWArtikelFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> NKWArtikelFreitextSuchHistory
        {
            get;
        }


        /// <summary>
        /// Fügt einen String aus der PKWArtikel-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddMotorenArtikelFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die PKWArtikelFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> MotorenArtikelFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der PKWArtikel-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddAchsenArtikelFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die PKWArtikelFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> AchsenArtikelFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der PKWArtikel-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddUniversalArtikelFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die PKWArtikelFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> UniversalArtikelFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der NummernArtikel-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddNummernArtikelFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die NummernArtikelFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> NummernArtikelFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Arbeitswerte Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddArbeitswerteFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die ArbeitswerteFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> ArbeitswerteFreitextSuchHistoy
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Wartungs-Arbeitswerte-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddWartungsArbeitswerteFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die WartungsArbeitswerteFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> WartungsArbeitswerteFreitextSuchHistoy
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Wartungs-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddWartungFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die WartungsFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> WartungsFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Wartungs-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddTechnikFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die WartungsFreitextsuche
        /// </summary>
        IList<FreitextSuchHistory> TechnikFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Trainings-Orte-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddTrainingOrtFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die Trainings-Orte-Freitextsuche
        /// </summary>
        IList<FreitextSuchHistory> TrainingOrtFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der Trainings-Orte-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddTrainingKategorieFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die Trainings-Orte-Freitextsuche
        /// </summary>
        IList<FreitextSuchHistory> TrainingKategorieFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der PlusKontoauszug-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddPlusAuszugFreitextSuchString( string _toSearch );


        /// <summary>
        /// Liefert die SuchHistory für die PlusKontoauszug-Freitextsuche
        /// </summary>
        IList<FreitextSuchHistory> PlusAuszugFreitextSuchHistory
        {
            get;
        }

        /// <summary>
        /// Fügt einen String aus der BestellHistory-Freitextsuche der History hinzu
        /// </summary>
        /// <param name="_toSearch">Der hinzuzufügende String</param>
        void AddBestellHistoryFreitextSuchString( string _toSearch );

        /// <summary>
        /// Liefert die SuchHistory für die PlusKontoauszug-Freitextsuche
        /// </summary>
        IList<FreitextSuchHistory> BestellungFreitextSuchHistory
        {
            get;
        }

        #endregion
    }
}
