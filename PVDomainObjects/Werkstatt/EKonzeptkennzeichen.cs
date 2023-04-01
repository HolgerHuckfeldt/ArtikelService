/********************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Stammdatenverwaltung
 * Funktionen:  Kapselt die Informationen, welche Konzeptkennzeichen unter welcher Nummer geführt werden
 *******************************************************************************************************/

using System;

namespace PV.DomainObjects.Stammdaten
{
    [Serializable]
    public enum EKonzeptkennzeichen
    {
        Autofit = 8,
        Meinewerkstatt = 20,
        Autoprofi = 35,
        Truckprofi = 36,
        PV_KOMPASS = 37,
        PV_KOMPASS_Kompakt = 38,
        PV_PLUS = 39,
        MediaMaster = 40,
        PV_Partner_Handel = 43,
        PV_Partner_Werkstatt = 44,
        TUEV_Zertifikat = 45,
        Vereinb_TUEV_Zertifizierung = 46,
        PV_Tankestelle = 51,
        PV_PLUS_Tanke = 55,
        PitStop = 54,
        CLUB_PV = 56,
        PitStop_FRANCHISE = 58,
        TrainingsCard25 = 66,
        TrainingsCard50 = 67,
        TrainingsCard100 = 68,
        TrainingsCardAnwaerter = 69, 
        Kein_PV_Live_Reiter = 999

    };
}
