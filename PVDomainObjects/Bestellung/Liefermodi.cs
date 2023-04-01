/*********************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Walter Licht / Dirk Lannatewitz   
 * Modul:    Bestellung   
 * Funktionen:  Domainobjekt für eine Bestellbestätigung
 ********************************************************************************************/

using System;
using System.Runtime.Serialization;
namespace PV.DomainObjects.Bestellung
{
    [DataContract]
    [Serializable]
    public enum Liefermodi
    {
        [EnumMember]
        Anlieferung,
        [EnumMember]
        Gesamtlieferung,
        [EnumMember]
        Terminlieferung,
        [EnumMember]
        Selbstabholung
    }

   
}
