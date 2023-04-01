using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.TemotDosi;
using System.Collections.ObjectModel;

namespace PV.Business.Services
{
	public interface IMotortesterManager
	{
		ObservableCollection<DosiTicket> Tickets { get; }

		ObservableCollection<DosiTicket> VisibleTickets { get; }

		bool ShowAll { get; set; }
        void RefreshSelected();
		void RefreshTickets();
		bool HasTickets { get; }
		int NumNewTickets();      
		DosiTicket SelectedTicket { get; }
        //void SelectTicket(DosiTicket o);
		string SelectedGenArtNr { get; }
		string SelectedArtikelNr { get; }
        string SelectedDesignation { get; }
		void SetSelectedTicket(DosiTicket ticket);
		void ClearSelectedTicket();
		bool HasSelectedTicket { get; }

		void UpdateTicket(DosiTicket t, int status);

		void ArtikelsucheStarten(string artikelNr, string genArtNr, string designation);
        //void ArtikelsucheStarten(string artikelNr, List<string> genArtNrs);
		bool IsSearchActive { get; set; }
	}
}
