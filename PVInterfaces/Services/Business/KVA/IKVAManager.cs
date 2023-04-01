/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    KVAIdentifikation
* Funktionen: Abstrahiert die Schnittstelle des KVAManagers und definiert seine Delegates 
*****************************************************************************************************/
using System.Collections.Generic;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.Kunden;
using PV.DomainObjects.KVA;
using PV.DomainObjects.Stammdaten;
using System;
using PV.DomainObjects.Wartung;
using PV.Utilities.Interfaces;
using PVInterfaces.Enums;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Businesslayers zum Frontend bezüglich der KVA
    /// </summary>
    public interface IKVAManager : ISearchByStringManager
    {
        #region KVA-Verwaltung

        /// <summary>
        /// Liefert die Liste aller KVA
        /// </summary>
        IList<KVA> KVAListe
        {
            get;
        }

        /// <summary>
        /// Liefert die Liste der anzeigbaren KVA
        /// </summary>
        IList<KVA> ViewableKVAListe
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt den selektierten KVA
        /// </summary>
        KVA SelectedKVA
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Info ob ein KVA gerade neu geöffnet wurde
        /// </summary>
        bool KVAgeradeGeoeffnet
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert die Artikelnummern der eigenen Artikel, die zwar in einem KVA gespeichert sind, 
        /// diese es aber nicht mehr in der Eigenen Artikel Liste gibt
        /// </summary>
        List<string> NichtVorhandeneEigeneArtikel
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt den SelectedPKW
        /// </summary>
        PKWTyp SelectedPKW
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert und setzt die Information ob der aktuelle KVA im Calcmode befindet
        /// </summary>
        bool CalcMode
        {
            get;
            set;
        }

        /// <summary>
        /// Liefert den Umfasst-Wert, der angibt, ob die Umfasst-Werte bei den Arbeitswerten angezeigt werden sollen
        /// </summary>
        /// <returns>bool-wert</returns>
        bool UmfasstAktiviert { get; set; }

        /// <summary>
        /// Liefert eine Liste von KVAs für einen Kunden
        /// </summary>
        /// <param name="_kunde">Der Kunde für welchen die KVA-Liste angefordert wird</param>
        /// <returns>Liste von KVAs, leere Liste wenn kein KVA für diesen Kunden vorhanden ist</returns>
        IList<KVA> GetKVAListForKunde( Kunde _kunde );

        /// <summary>
        /// Liefert einen leeren KVA
        /// </summary>
        /// <returns>Ein KVAobjekt</returns>
        KVA GetEmptyKVA();

        /// <summary>
        /// Liefert eine neue KVA-Nummer
        /// </summary>
        /// <returns>Die nächste freie KVA-Nummer</returns>
        int GetNewKVANumber();

        /// <summary>
        /// Liefert eine neue Nummer aus dem Rechnungs-Nummernkreis.
        /// </summary>
        /// <returns></returns>
        int GetNewRechnungsNumber();

        /// <summary>
        /// Gibt eine nicht benutzte Rechnungsnummer wieder frei.
        /// </summary>
        /// <param name="nummer"></param>
        void ReleaseRechnungsNummer(int nummer);

        /// <summary>
        /// Eine REchnungsnummer konfigurieren
        /// </summary>
        /// <param name="nummer"></param>
        void SetRechnungsNummer(int nummer);

        /// <summary>
        /// Speichert einen KVA
        /// </summary>
        /// <param name="_kva">Der zu speichernde KVA</param>
        /// <returns>Das Ergebnis des Speicherns als SaveResult</returns>
        SaveResults SaveKVA( KVA _kva );

        /// <summary>
        /// Löscht einen KVA
        /// </summary>
        /// <param name="_kva">Der zu löschende KVA</param>
        /// <returns>Das Ergebnis des Löschens als SaveResult</returns>
        SaveResults DeleteKVA( KVA _kva );

        /// <summary>
        /// Resetet die ViewableKVAListe, so dass sie alle KVA der KVAListe enthält
        /// </summary>
        void ResetViewableKVAListe();

        /// <summary>
        /// Lädt die Liste der Positionen des gewählten KVAs für eine Readonly Anzeige
        /// </summary>
        /// <param name="_kva">Der zu öffnende KVA</param>
        void OpenKVAReadOnly( KVA _kva );

        KVA GetkVAReadOnly(KVA _kva);

        /// <summary>
        /// Lädt die Liste der Positionen des gewählten KVAs für eine weitere Verarbeitung
        /// </summary>
        /// <param name="_kva">Der zu öffnende KVA</param>
        void OpenKVAEditable( KVA _kva );

        /// <summary>
        /// Erstellt einen neuen KVA und füllt diesen mit den Positionen des Warenkorbes
        /// </summary>
        void CreateFromWarenkorb();

        #endregion

        #region KVA Manipulation

        /// <summary>
        /// Fügt dem Selected KVA einen Artikel hinzu
        /// </summary>
        /// <param name="_artikel">Der hinzuzufügende Artikel</param>
        /// <param name="_menge">Die hinzuzufügende Menge</param>
        void Add( Artikel _artikel, decimal _menge );

        /// <summary>
        /// Fügt dem Selected KVA einen Eingenen Artikel hinzu
        /// </summary>
        /// <param name="_artikel">Der hinzuzufügende Artikel</param>
        /// <param name="_menge">Die hinzuzufügende Menge</param>
        void Add( EigenerArtikel _artikel, decimal _menge );

        /// <summary>
        /// Update eines EA im KVA
        /// </summary>
        /// <param name="artikel"></param>
        void Update(EigenerArtikel artikel);

        /// <summary>
        /// Update eines EAw im KVA
        /// </summary>
        /// <param name="aw"></param>
        void Update(EigenerArbeitswert aw);

        /// <summary>
        /// Fügt dem Selected KVA einen Arbeitsprozess (Arbeitswert) hinzu
        /// </summary>
        /// <param name="_prozess">Der hinzuzufügende Arbeitsprozess</param>
        /// <param name="_wert">Der eingetragene Wert</param>
        /// <param name="_art">Die Arbeitswertart</param>
        void Add( Arbeitsprozess _prozess, double _wert, ArbeitswertArt _art );

        /// <summary>
        /// Fügt dem Selected KVA einen Arbeitsprozess (Arbeitswert) hinzu
        /// </summary>
        /// <param name="_prozess">Der hinzuzufügende Arbeitsprozess</param>
        /// <param name="_wert">Der eingetragene Wert</param>
        void Add( Arbeitsprozess _prozess, double _wert );

        /// <summary>
        /// Fügt dem Selected KVA eine Wartung hinzu
        /// </summary>
        /// <param name="prozess">Der zusammenfassende hinzuzufügende Arbeitsprozess</param>
        /// <param name="checklistenitems">Die zugrundeliegenden WartungsChecklisteItem</param>
        void Add(Arbeitsprozess prozess, IEnumerable<WartungsChecklisteItem> checklistenitems);

        /// <summary>
        /// Aktualisiert eine Wartung, falls vorhanden.
        /// </summary>
        /// <param name="prozess">Der zusammenfassende hinzuzufügende Arbeitsprozess</param>
        /// <param name="checklistenitems">Die zugrundeliegenden WartungsChecklisteItem</param>
        void Update(Arbeitsprozess prozess, IEnumerable<WartungsChecklisteItem> checklistenitems);

        /// <summary>
        /// Fügt dem Selected KVA einen Arbeitsprozess (Arbeitswert) hinzu
        /// </summary>
        /// <param name="_prozess">Der hinzuzufügende Arbeitsprozess</param>
        void Add( Arbeitsprozess _prozess );

        /// <summary>
        /// Fügt dem Selected KVA einen eigenen Arbeitswert hinzu
        /// </summary>
        /// <param name="_prozess">Der hinzuzufügende Arbeitswert</param>
        /// <param name="_wert">Der eingetragene Wert</param>
        /// <param name="_art">Die Arbeitswertart</param>
        void Add( EigenerArbeitswert _prozess, decimal _wert, ArbeitswertArt _art );

        /// <summary>
        /// Setzt den Kunden das KVA
        /// </summary>
        /// <param name="_kunde">Der zu setzende Kunde</param>
        bool SetKundeForKVA( Kunde _kunde );

        #endregion

        /// <summary>
        /// Fügt eine übergebene Position dem Warenkorb hinzu
        /// </summary>
        /// <param name="_position">Die hinzuzufügende Position</param>
        void AddToWarenkorb( KVAPosition _position );

        /// <summary>
        /// Fügt alle entsprechend gekennzeichneten Positionen dem Warenkorb hinzu
        /// </summary>
        void AddToWarenkorb();

        /// <summary>
        /// Sendet die Liste der Positionen an Repdoc
        /// </summary>
        void SentToRepdoc();

        void LoadKvaList();

        void LoadKvaList(int ktype);

        bool SammelnInKva { get; set; }

    }
}
