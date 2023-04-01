using System.Collections.Generic;
using PV.DomainObjects.Bestellung;
using PV.DomainObjects.Warenkorb;
using PVInterfaces.Enums;
using Pv.Services.Shared.Dtos;
using System;

namespace PV.Business.Services
{
	public interface IBestellManager : ISearchByStringManager
	{

		//void LoadAllBestellungen();

        bool BestellhistoriePopupListeIsOpen { get; set; }
        
		/// <summary>
		/// Liefert eine Liste aller Bestellungen von heute
		/// </summary>
		IList<bsBestellung> BestellungsListeToday
		{
			get;
		}

		IList<bsBestellung> OfflinePendingBestellungsListe
		{
			get;
		}

		void UeberpruefeOffeneOfflineWarenkorbPositionen(bool firstLoaded);

		bool UeberpruefeOffeneOfflineWarenkorbPositionen(string OfflineBestellId);

		/// <summary>
		/// Liefert eine Liste aller Bestellungen von gestern
		/// </summary>
		IList<bsBestellung> BestellungsListeYesterday
		{
			get;
		}
		/// <summary>
		/// Liefert eine Liste aller Bestellungen älter als gestern
		/// </summary>
		IList<bsBestellung> BestellungsListeOld
		{
			get;
		}

		/// <summary>
		/// Liefert eine Liste aller Bestellungen, diese kann gefiltert werden
		/// </summary>
		IList<bsBestellung> ViewableBestellungsListe
		{
			get;
		}

		/// <summary>
		/// Resettet die Viewable Bestellliste
		/// </summary>
		void ResetViewableBestellListe();

		/// <summary>
		/// Laden der OfflinePositionen, die von der VDB nicht erfolgreich waren
		/// </summary>
		OrderServiceResult LoadOfflinePositionen(string offlineID);

		/// <summary>
		/// Close einer OfflineBestellung
		/// </summary>
		void OfflineBestellungSchliessen(string offlineID);

		/// <summary>
		/// Lädt Die Bestellhiostorie für Teaser
		/// </summary>
		void LoadBestellhistorieKurz(bool artikelNeuLaden);

		/// <summary>
		/// Lädt Die Bestellhiostorie für Popup
		/// </summary>
		//void LoadBestellhistorieZeitraum(DateTime von, DateTime bis);
		void LoadBestellhistorieZeitraum(DateTime von, DateTime bis, string suchtext, int startindex, int max, bool? praesentation, string bestellart);

		/// <summary>
		/// Löscht eine gespeicherte Bestellung
		/// </summary>
		/// <param name="_toDelete">Die zu löschene Bestellung</param>
		/// <returns>Das Ergebnis als SaveResult</returns>
		SaveResults DeleteBestellung(bsBestellung _toDelete);

		/// <summary>
		/// Sichert den aktuellen Warenkorb als Druckbestellung
		/// </summary>
		void SaveAlsDruckbestellung(IWarenkorb _warenkorb);
		bsBestellung BestellWarenkorb(IWarenkorb _warenkorb, bool showbonus, bool showpreise);
	}
}
