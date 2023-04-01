/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Dirk Lannatewitz / Walter Licht
 * Modul:       Warenkorb 
 * Funktionen:  Abstrahiert die Schnittstelle eines Warenkorb-Managers und definiert dessen Delegates
 *              DIESES IST EIN WORKARROUND BIS VORGABEN VON BB&K VOREHANDEN SIND
 *              Noch ist nicht bekannt, wem gehört der WK... Dem User, der Werkstatt... Wer darf diesen sehen...
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects;
using PV.DomainObjects.Warenkorb;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Warenkorb.Kalender;
using PV.Utilities.Misc;


namespace PV.Business.Services
{
    public interface IWarenkorbManager
    {
        #region Properties

        DateTime ServerTime { get; set; }
        DateTime LastCheckServerTime { get; set; }

        List<int> LieferBonusSchranken
        { get; set; }

        List<int> LieferBonusWerte
        { get; set; }

        List<DateTime> NeinTage
        { get; set; }

        List<wkMonth> LieferKalender
        {
            get;
        }

        /// <summary>
        /// liefert die Anzahl der Rückstandsartikel zurück
        /// </summary>
        int Rueckstandsmenge
        {
            get;
        }

        /// <summary>
        /// liefert die KontoInformationen eines Profiles zurück
        /// </summary>
        KontoInfos KontoInformationen
        {
            get;
            set;
        }

        /// <summary>
        /// liefert true, wenn der aktuelle Warenkorb leer ist
        /// </summary>
        bool IsEmpty
        {
            get;
        }
        
        /// <summary>
        /// Die Liste der Rückstaende des Users bei PV
        /// </summary>
        IList<Rueckstand> Rueckstandsliste
        {
            get;
        }

        /// <summary>
        /// Die Rückstandsliste soll neu geladen werden.
        /// </summary>
        void InvalidateRueckstandsListe();

        /// <summary>
        /// Gibt zurück ob der Warenkorb im aktuellen zustand gespeichert ist
        /// </summary>
        bool IsWarenkorbPersistent
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt zurück ob das Warenkorb Fenster geladen ist oder nicht
        /// </summary>
        bool IsWarenkorbWindowLoaded
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt zurück ob das Schnellmodusartikelfenster offen oder nicht offen ist
        /// </summary>
        bool IsSchnellmodusartikelfensterLoaded
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gibt an ob der Warenkorb serialisiert werden kann
        /// </summary>
        bool CanSerialize
        {
            get;
        }

        /// <summary>
        /// Gibt eine Liste aller persistierten Warenkörbe zurück
        /// </summary>
        /// <returns></returns>
        IList<WarenkorbInfo> WarenkorbListe
        {
            get;
        }

        /// <summary>
        /// Liefert den Busy Status,
        /// ist der Warenkorb busy darf das Frontend keine Anfragen an ihn senden
        /// </summary>
        bool IsBusy
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        string Reservierung
        {
            get;
        }



        /// <summary>
        /// Liefert den aktuellen Warenkorb
        /// </summary>
        IWarenkorb CurrentWarenkorb
        {
            get;
        }

        /// <summary>
        /// Liefert den sichtbaren Warenkorb
        /// (enthält keine Artikel mit dem Action Status "löschen"
        /// </summary>
        Warenkorb VisibleWarenkorb
        {
            get;
        }

        #endregion
        
        /// <summary>
        /// Erzeugt einen neuen Warenkob und setzt diesen als den aktuellen
        /// </summary>
        void CreateWarenkorb(bool createEmptyWk);

        /// <summary>
        /// Storniert den aktuellen Warenkorb
        /// </summary>
        void Stornieren(VdbUserInfo _userinfo);

        void Stornieren(bool warenkorbErhalten, VdbUserInfo userinfo);

        void StornierenNachWindowsClosing();

        /// <summary>
        /// Liefert eine ItemListe für die Artikeldetails
        /// </summary>
        /// <param name="_position"></param>
        /// <returns></returns>
        PVItemListe<Artikel> GetItenListForPosition(IWarenkorbPosition _position);

        /// <summary>
        /// Liefert die Alternativen zur angegebenen Position
        /// </summary>
        /// <param name="_position"></param>
        /// <returns></returns>
        List<wkAlternativArtikel> GetAlternativenForPosition(IWarenkorbPosition _position);

        /// <summary>
        /// Löscht einen Rückstand des Kunden bei PV
        /// </summary>
        /// <param name="_rueckstand"></param>
        void RueckstandLoeschen(Rueckstand _rueckstand);

        /// <summary>
        /// Gibt (falls vorhanden) ein Artikel Domain Object für die entsprechende Position zurück
        /// </summary>
        /// <param name="_position"></param>
        /// <returns></returns>
        Artikel GetArtikelForPosition(Position _position);

        /// <summary>
        /// Speichert den aktuellen Warenkorb
        /// </summary>
        void Save();

        VDBGetLoginResponse GetLogin();

        /// <summary>
        /// Für den Fall dass Kompass abgestürzt ist existiert in der VDB noch ein Warenkorb. Dieser hat die GetLogin()::BestellID und
        /// wird mit dieser Methode geladen
        /// </summary>
        /// <param name="_warenkorb"></param>
        void LoadWarenkorbFromVdb();

        /// <summary>
        /// Lädt den genannten Warenkorb und setzt ihn als Current
        /// </summary>
        /// <param name="_warenkorb"></param>
        void LoadWarenkorb(WarenkorbInfo _warenkorb);

        /// <summary>
        /// Löscht den genannten Warenkorb
        /// </summary>
        /// <param name="?"></param>
        void Delete(WarenkorbInfo _warenkorb);

        /// <summary>
        /// Sichert den aktuellen Warenkorb als Druckbestellung
        /// </summary>
        void SaveAlsDruckbestellung();
        
        /// <summary>
        /// Bestellt den aktuellen Warenkorb
        /// </summary>
        void Bestellen(bool showbonus,bool showpreise);

        /// <summary>
        /// Aktualisiert den akt. Warenkorb
        /// bzw. führt die VDB Validierung durch
        /// </summary>
        void UpdCurrentWarenkorb();

        void GetAlternativen(Position _position);

        DateTime Liefertour { get; }
        DateTime AktuellePVServerzeitLiefertour { get; }
        void OnUpdLiefertour();
        void AlterPosition(IWarenkorbPosition position, Artikel tauschArtikel, int menge);

        void GetRueckstandsListeSync();
        bool GetWarenkorbNichtSortieren();
        void SaveWkNichtSortieren(bool wkNichtSortieren);

        bool IsVdbOnline { get; }
    }
}
