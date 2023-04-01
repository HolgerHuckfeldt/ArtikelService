/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz
 * Modul:       KVA Verwaltung 
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die KVA erfüllen muss
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.KVA;
using PVInterfaces.Enums;


namespace PV.Persistance.Provider
{

    public interface IKVAPersistanceProvider
    {
        /// <summary>
        /// Initiirt das Laden der KVAListe
        /// </summary>
        
        List<KVA> LoadKVAListe();

        /// <summary>
        /// Hier wird überprüft, ob die KVAListe sich geändert hat
        /// </summary>
        
        bool UeberpruefeKVAListe(int aktuellCount);

        /// <summary>
        /// Speichert einen übergebenen KVA
        /// </summary>
        /// <param name="_kva">Der zu speichernde KVA</param>
        /// <param name="_positions">Die serialisierte Liste der Positionen</param>
        /// <returns>Das Speicherergebnis in Form eines SaveResults</returns>
        
        SaveResults SaveKVA( KVA _kva, byte[] _positions );

        /// <summary>
        /// Liefert die serialisierte Liste der KVA-Positionen zu einem KVA
        /// </summary>
        /// <param name="_kvaId">Die Guid des Kva für welchen die Positionen geladen werden sollen</param>
        /// <returns>Liste der serialisierten KVA-Positionen</returns>
        
        byte[] GetPositionsForKVA( Guid _kvaId );

        /// <summary>
        /// Löscht einen übergebenen KVA
        /// </summary>
        /// <param name="_kvaId">Die Guid des zu löschenden Kva</param>
        /// <returns>Das Ergebnis des Löschens in Form eines SaveResults</returns>
        
        SaveResults DeleteKVA( Guid _kvaId );

        /// <summary>
        /// Liefert die Maximale KVAnummer inkrementiert um 1
        /// </summary>
        /// <returns>Die neue KVAnummer</returns>
        
        int GetNextKVANummer();

        /// <summary>
        /// Muss vom Client in Intervallen kleibner 10min aufgerufen werden.
        /// </summary>
        
        void Alive();

        /// <summary>
        /// Zusatzinfoa von einem KVA lesen
        /// </summary>
        /// <param name="kva"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        
        string GetAdditionalData( Guid kva, string key);

        /// <summary>
        /// Zusatzinfoa von einem KVA lesen
        /// </summary>
        /// <param name="kva"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        
        List<KeyValuePair<Guid,string>> GetAdditionalDataList(List<Guid> kvas, string key);

        /// <summary>
        /// Zusatzinfoa an einen KVA hängen
        /// </summary>
        /// <param name="kva"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        
        void SetAdditionalData(Guid kva, string key, string value);

        
        int GetNextRechnungsNummer();

        
        void SetRechnungsNummer(int nummer);

        
        void ReleaseRechnungsNummer(int nummer);

    }
}
