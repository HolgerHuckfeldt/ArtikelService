using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVInterfaces.Services
{
    public partial class NavigationTarget
    {
        /*
         * Remarks:
         * This class should contain only predefined instances of navigation targets
         */

        private const string MainTabName = "tabWindow";
        private const string KompassMainTab = "tabMain";
        private const string LmsMainTab = "tabMain_PvTraining";
        private const string PlusMainTab = "tabMain_PvPlus";

        public static NavigationTarget PVKompass =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" );

        public static NavigationTarget PVPlus =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" );

        public static NavigationTarget PVTraining=
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVTraining" );

        public static NavigationTarget PVMeineWerkstatt=
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabWerkstatt" );


        public static NavigationTarget StartSeite =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabStartSeite" );


        public static NavigationTarget Fahrzeugauswahl =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabFahrzeuge" );

        public static NavigationTarget KompassFIdentPKW =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabFahrzeuge" )
                .AddControlNavigation( "ctrlFahrzeugsuche" )
                .AddTabNavigation( "tabFIdentArt", "TabItemPKW" );

        public static NavigationTarget KompassFIdentNKW =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabFahrzeuge" )
                .AddControlNavigation( "ctrlFahrzeugsuche" )
                .AddTabNavigation( "tabFIdentArt", "TabItemNKW" );

        public static NavigationTarget KompassFIdentMotoren =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabFahrzeuge" )
                .AddControlNavigation( "ctrlFahrzeugsuche" )
                .AddTabNavigation( "tabFIdentArt", "TabItemMotoren" );

        public static NavigationTarget KompassFIdentAchsen =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabFahrzeuge" )
                .AddControlNavigation( "ctrlFahrzeugsuche" )
                .AddTabNavigation( "tabFIdentArt", "TabItemAchsen" );

        public static NavigationTarget KompassAIdentFahrzeug =
            new NavigationTarget()
        .AddTabNavigation( MainTabName, "TabPVKompass" )
        .AddTabNavigation( KompassMainTab, "tabArtikel" )
        .AddControlNavigation( "ctrlArtikelsuche" )
        .AddTabNavigation( "tabArtikelSuchen", "TabItemFZArtikel" );

        public static NavigationTarget KompassAIdentUniversal =
            new NavigationTarget()
        .AddTabNavigation( MainTabName, "TabPVKompass" )
        .AddTabNavigation( KompassMainTab, "tabArtikel" )
        .AddControlNavigation( "ctrlArtikelsuche" )
        .AddTabNavigation( "tabArtikelSuchen", "TabItemUniversalArtikel" );

        public static NavigationTarget KompassAIdentEigene =
            new NavigationTarget()
        .AddTabNavigation( MainTabName, "TabPVKompass" )
        .AddTabNavigation( KompassMainTab, "tabArtikel" )
        .AddControlNavigation( "ctrlArtikelsuche" )
        .AddTabNavigation( "tabArtikelSuchen", "TabItemEigeneArtikel" );

        public static NavigationTarget KompassAIdentNummern =
            new NavigationTarget()
        .AddTabNavigation( MainTabName, "TabPVKompass" )
        .AddTabNavigation( KompassMainTab, "tabArtikel" )
        .AddControlNavigation( "ctrlArtikelsuche" )
        .AddTabNavigation( "tabArtikelSuchen", "TabItemNummernSuche" );


        public static NavigationTarget Warenkorb =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabWarenkorb" );

        public static NavigationTarget Kva =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabKVA" );

        public static NavigationTarget Arbeitswerte =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabArbeitswerte" );

        public static NavigationTarget LmsTrainingsStartseite =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabPVTraining")
                .AddTabNavigation(LmsMainTab, "tabTrainingsStartseite");

        public static NavigationTarget LmsTrainingsKatalog =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVTraining" )
                .AddTabNavigation( LmsMainTab, "tabTrainingsKatalog" );

        public static NavigationTarget LmsMeinTraining =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabPVTraining")
                .AddTabNavigation(LmsMainTab, "tabMeinTraining");

        public static NavigationTarget LmsTrainingsCard =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabPVTraining")
                .AddTabNavigation(LmsMainTab, "tabTrainingsCard");

        public static NavigationTarget Artikel =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabArtikel" );

        public static NavigationTarget PlusStartSeite =
            new NavigationTarget()
        .AddTabNavigation( MainTabName, "TabPVPlus" )
        .AddTabNavigation( PlusMainTab, "tabPlusStartseite" );

        public static NavigationTarget PlusInformationen =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabPlusInformationen" );

        public static NavigationTarget PlusPraemienwelt =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabPlusPraemienwelt" );

        public static NavigationTarget PlusTrainings =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabTrainingsStartseite" );

        public static NavigationTarget PlusUeberPlus =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabPlusInformationen" )
                //.AddControlNavigation( "PagePlusInformationen" )
                .AddControlNavigation( "PlusVorteile" )
                .AddTabNavigation( "tabControlUeberPVPLus", "tabItemDasIstPlus" );

        public static NavigationTarget PlusPunkteEinloesen =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabPlusInformationen" )
                //.AddControlNavigation( "PagePlusInformationen" )
                .AddControlNavigation( "PlusVorteile" )
                .AddTabNavigation( "tabControlUeberPVPLus", "tabItemPunkteEinloesen" );

        public static NavigationTarget PlusPunkteSammeln =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabPlusInformationen" )
                //.AddControlNavigation( "pagePlusInformationen" )
                .AddControlNavigation( "PlusVorteile" )
                .AddTabNavigation( "tabControlUeberPVPLus", "tabItemPunkteSammeln");

        public static NavigationTarget PlusKontoauszug =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabPlusKontoauszug" );

        public static NavigationTarget PlusWarenkorb =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVPlus" )
                .AddTabNavigation( PlusMainTab, "tabPlusWarenkorb" );

        #region Marketingreiter

        public static NavigationTarget Marketing =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabMarketing");

        public static NavigationTarget MarketingAutoprofi =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabMarketingAutoprofi");


        public static NavigationTarget MarketingTruckprofi =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabMarketingTruckprofi");

        public static NavigationTarget MarketingAutofit =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabMarketingAutofit");

        public static NavigationTarget MarketingMeineWerkstatt =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabMarketingMeineWerkstatt");

        public static NavigationTarget MarketingClubPv =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "TabMarketingClubPv");

        public static NavigationTarget MarketingPvLive2 =
            new NavigationTarget()
                .AddTabNavigation(MainTabName, "MarketingPvLive2");

        #endregion

        public static NavigationTarget ArtikelNummernSuche =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabArtikel" )
                .AddControlNavigation( "pageKompassArtikel" )
                .AddControlNavigation("ctrlArtikelsuche")
                .AddTabNavigation( "tabArtikelSuchen", "TabItemNummernSuche" );

        public static NavigationTarget Technik =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabTechnik" );

        public static NavigationTarget Wartung =
            new NavigationTarget()
        .AddTabNavigation( MainTabName, "TabPVKompass" )
        .AddTabNavigation( KompassMainTab, "tabWartung" );

        public static NavigationTarget Assistent =
            new NavigationTarget()
                .AddTabNavigation( MainTabName, "TabPVKompass" )
                .AddTabNavigation( KompassMainTab, "tabAssistent" );
    }
}
