/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       Bestellungen Verwaltung 
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Bestellungen erfüllen muss
 *********************************************************************************************************/

using System;
using System.Collections.Generic;

using PV.DomainObjects.Bestellung;
using PVInterfaces.Enums;


namespace PV.Persistance.Provider
{
  
    public interface IBestellungHistoryPersistanceProvider
    {
        /// <summary>
        /// Überprüfen, ob in der Stammdaten-DB neue Bestellungen vorhanden sind (Clients, Server-Geschichte)
        /// </summary>
        
        bool UeberpruefeBestelliste(int alteAnzahlBestellhistorie);

        /// <summary>
        /// Initiirt das Laden der Bestellung-Liste
        /// </summary>
        
        List<bsBestellung> LoadBestellListeNeu(int count);

		///// <summary>
		///// Initiirt das Laden der Bestellung-Liste
		///// </summary>
		//
		//List<bsBestellung> LoadBestellListeNeu(DateTime von, DateTime bis);
		
		/// <summary>
        /// Initiirt das Laden der Bestellung-Liste
        /// </summary>
        
        List<bsBestellung> LoadBestellListe();

        /// <summary>
        /// Initiirt das Laden der Offline-Bestellung-Liste
        /// </summary>
        
        List<bsBestellung> LoadOfflineBestellListeNeu(int count);

        /// <summary>
        /// Initiirt das Laden der Offline-Bestellung-Liste
        /// </summary>
        
        List<bsBestellung> LoadOfflineBestellListe();

        /// <summary>
        /// Initiirt das Laden der Offline-Bestellung-Liste, die noch offen sind
        /// </summary>
        
        List<bsBestellung> LoadPendingOfflineBestellListeNeu(int count);

        /// <summary>
        /// Initiirt das Laden der Offline-Bestellung-Liste, die noch offen sind
        /// </summary>
        
        List<bsBestellung> LoadPendingOfflineBestellListe();


        /// <summary>
        /// Status der Bestellung auf erledigt
        /// </summary>
        /// <param name="offlineId"></param>
        /// <returns></returns>
        
        void CloseOfflineBestellung(string offlineId);

        /// <summary>
        /// Speichert eine übergebenen Bestellung
        /// </summary>
        /// <param name="_bestellung">Die zu speichernde Bestellung</param>
        /// <returns>Das Speicherergebnis in Form eines SaveResults</returns>
        
        SaveResults SaveBestellung(bsBestellung _bestellung, String UserId, String ProfilString);

        /// <summary>
        /// Löscht eine gespeicherte Bestellung
        /// </summary>
        /// <param name="_toDelete">Die zu löschene Bestellung</param>
        /// <returns>Das Ergebnis als SaveResult</returns>
        
        SaveResults DeleteBestellung( bsBestellung _toDelete );

        /// <summary>
        /// Liefert die serialisierte Liste der Positionen zu einer Bestellung
        /// </summary>
        /// <param name="_bestellung">Die Bestellung für welchen die Positionen geladen werden sollen</param>
        /// <returns>Liste der serialisierten Positionen</returns>
        
        byte[] GetPositionsForBestellung(bsBestellung _bestellung);

        /// <summary>
        /// Hält die Named-Pipe offen
        /// </summary>
        
        void Alive();
    }
}
