/******************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz
 * Modul:    Kundenverwaltung   
 * Funktionen:  Stellt Informationen zur Verfügung, m welche Art Ressource es sich handelt
 ******************************************************************************************************************/

using System;

namespace PV.DomainObjects.Kunden
{
    [Serializable]
    public enum KundenRessourcenArt
    {
        Achse,
        Motor, 
        Nkw, 
        Pkw,
    }
}
