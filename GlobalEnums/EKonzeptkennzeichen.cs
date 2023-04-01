using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalEnums
{
    [Serializable]
    public enum EKonzeptkennzeichen
    {
        _KeinKKZ = 0,
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
        Motortester = 71,
        FlexReiter = 72,
        MobileApp = 73,
        Reifen = 74,
        PV_KOMPASS_Grafische_Suche_Schwacke = 75,
        PV_KOMPASS_Raederkonfigurator = 76,
        PV_KOMPASS_Alldata = 77,
        Glasschaden = 78,
        PV_PLUS_Basic = 79,
        PV_KOMPASS_DAT = 80,
        PV_KOMPASS_Autodata = 81,
        PV_KOMPASS_Entsorgung = 82,
        PV_KOMPASS_TecCom = 83,
        PV_KOMPASS_CONNECT = 84,
        Kein_PV_Live_Reiter = 999,
        Zahlungsmodus = 5005
        // wenn das gesetzt ist, wird PV:LIVE/PV:SALE nicht angezeigt - Plugin der Markowitztruppe
    };
}
