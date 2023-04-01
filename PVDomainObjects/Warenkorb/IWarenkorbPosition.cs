using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb
{
    public interface IWarenkorbPosition : INotifyPropertyChanged
    {
        Artikel.Artikel ArtikelRef{ get; }
        Boolean Alternativen { get; }
        String Artikelnummer { get; }
        String Bezeichnung { get; }
        String Hersteller { get; }
        Decimal Menge { get; set; }
        long UmsatzBonus { get; set; }
        long AktionBonus { get; set; }
        long KonzeptBonus { get; set; }
        long TauschBonus { get; set; }
        long KompassBestellBonus { get; set; }
        long LieferBonus { get; set; }
        long SummeBonus { get; set; }
        long OnlineBonus { get; set; }
        String Steuerkennzeichen { get; }
        Decimal EkPreis { get; }
        Decimal VkPreis { get; }
        Decimal EkPreisSumme { get; }
        String UserText1 { get; set; }
        String UserText2 { get; set; }
        List<wkUnterPosition> Unterpositionen { get; }
        Int32 PositionNr { get; }
        wkPositionStatus VdbStatus { get; set; }
        Guid RepdocGuid { get; set; }
        String HLK { get; }
        Anlieferungsarten Anlieferungsart { get; set; }
        wkArtikelArt ArtikelArt { get; set; }

        // TecCom-Erweiterung
        Artikel.Artikel TecComTransportArtikelRef { get; set; }
        bool IsTecCom { get; set; }

    }
}
