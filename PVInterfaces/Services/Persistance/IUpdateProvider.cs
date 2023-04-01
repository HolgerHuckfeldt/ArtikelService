/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Achsidentifikation
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für den Achs Index erfüllen muss
 ***************************************************************************************************************************************/
using System.Collections.Generic;
using PV.DomainObjects.Fahrzeug;


namespace PV.Persistance.Provider
{
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für den Achs Index erfüllen muss
    /// </summary>
    
    public interface IUpdateProvider
    {

        /// <summary>
        /// Lädt Update-XMl für diesen Benutzer 
        /// </summary>
        
        string LoadUpdateInfos(string firma, string standort, string abteilung);

        /// <summary>
        /// Lädt Update-XMl für dieses Profil. 
        /// </summary>
        /// <param name="profilid"></param>
        /// <returns></returns>
        
        string LoadUpdateInfo(int profilid);

        
        string LoadUpdateInfosByList(List<int> profilids);

    }
}
