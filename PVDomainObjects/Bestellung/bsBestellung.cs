using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Bestellung
{
	//[DataContract]
	[Serializable]
	[KnownType(typeof(bsPosition))]
	[KnownType(typeof(List<bsPosition>))]
	[KnownType(typeof(Liefermodi))]
	public class bsBestellung : ISerializable
	{
		public bool OfflineZuOnline
		{
			get;
			set;
		}

		//[DataMember]
		public string Kundennummer
		{
			get;
			set;
		}

		//[DataMember]
		public string BestellnotizAngabe
		{
			get;
			set;
		}

		public string Bestellart
		{
			get;
			set;
		}

		public string BestellartAnzeige
		{
			get;
			set;
		}

		//[DataMember]
		public string Lieferzeitpunkt
		{
			get;
			set;
		}

		//[DataMember]
		public string BestellnotizBestellnummer
		{
			get;
			set;
		}

		//[DataMember]
		public Guid Id
		{
			get;
			set;
		}

		public int IdDB
		{
			get;
			set;
		}

		public bool VdbSoapAccesDirect { get; set; }

		//[NonSerialized]
		bool _PraesentationsBBS;
		public bool PraesentationsBBS
		{
			get
			{
				return _PraesentationsBBS;
			}
			set
			{
				_PraesentationsBBS = value;
			}
		}

		//[NonSerialized]
		bool _HandelspartnerBBS;
		public bool HandelspartnerBBS
		{
			get
			{
				return _HandelspartnerBBS;
			}
			set
			{
				_HandelspartnerBBS = value;
			}
		}

		//[DataMember]
		public Liefermodi Lieferart
		{
			get;
			set;
		}

		//[DataMember]
		public String Profilname
		{
			get;
			set;
		}

		//[DataMember]
		public String Lieferantenname
		{
			get;
			set;
		}

		//[DataMember]
		public String Benutzername
		{
			get;
			set;
		}

		//[DataMember]
		public string SortBenutzername
		{
			get
			{
				return string.Format("{0}{1}",Benutzername,Profilname);
			}
		}

		private long _BestellID;

		//[DataMember]
		public long BestellId
		{
			get { return _BestellID; }
			set { _BestellID = value; }
		}

		private string _OfflineBestellID;

		//[DataMember]
		public string OfflineBestellId
		{
			get { return _OfflineBestellID; }
			set { _OfflineBestellID = value; }
		}
		//[DataMember]
		public long ResponseID_ValidateWarenkorb
		{
			get;
			set;
		}

		//[DataMember]
		public long ResponseID_PerformBestellung
		{
			get;
			set;
		}

		//[DataMember]
		public String Firmenname
		{
			get;
			set;
		}

		//[DataMember]
		public String FirmenAdresszusatz
		{
			get;
			set;
		}

		//[DataMember]
		public String VersandadresseStrasse
		{
			get;
			set;
		}

		//[DataMember]
		public String VersandadressePlz
		{
			get;
			set;
		}

		//[DataMember]
		public String VersandadresseOrt
		{
			get;
			set;
		}

		//[DataMember]
		public String StandortName
		{
			get;
			set;
		}

		//[DataMember]
		public String StandortStrasse
		{
			get;
			set;
		}

		//[DataMember]
		public String StandortPlz
		{
			get;
			set;
		}

		//[DataMember]
		public String StandortOrt
		{
			get;
			set;
		}

		//[DataMember]
		public String StandortTel
		{
			get;
			set;
		}

		//[DataMember]
		public String StandortFax
		{
			get;
			set;
		}

		//[DataMember]
		public String WarenkorbImpressum
		{
			get;
			set;
		}

		//[DataMember]
		public Decimal WarenkorbSumme
		{
			get;
			set;
		}

		//[NonSerialized]
		private bool _NachtexpressVorhanden;
		public bool NachtexpressVorhanden
		{
			get { return _NachtexpressVorhanden; }
			set { _NachtexpressVorhanden = value; }
		}

		//[DataMember]
		public long GesamtBonuswert
		{
			get;
			set;
		}

		//[DataMember]
		public bool ShowBonus
		{
			get;
			set;
		}

		//[DataMember]
		public bool ShowPreise
		{
			get;
			set;
		}


		//[DataMember]
		public long KontoStand
		{
			get;
			set;
		}

		private DateTime _Bestellzeit;

		//[DataMember]
		public DateTime Bestellzeit
		{
			get { return _Bestellzeit; }
			set { _Bestellzeit = value; }
		}

		// [DataMember]
		public string Waehrung
		{
			get;
			set;
		}

		//[DataMember]
		public String Auftragsnummer
		{
			get;
			set;
		}

		//[DataMember]
		public String FileName
		{
			get;
			set;
		}

		//[DataMember]
		public List<bsPosition> Positionen
		{
			get;
			set;
		}
		//[DataMember]
		public List<bsPosition> FehlerhaftePositionen
		{
			get;
			set;
		}

		//[DataMember]
		public string Filename { get; set; }

		private string _Bestellstatus;

		//[DataMember]
		public String Bestellstatus //Online bestellt, nur geduckt...
		{
			get { return _Bestellstatus; }
			set { _Bestellstatus = value; }
		}

		//[DataMember]
		public long BonusPunktUmsatz { get; set; }
		//[DataMember]
		public long BonusPunktAktion { get; set; }
		//[DataMember]
		public long BonusPunktKompassBestellBonus { get; set; }
		//[DataMember]
		public long BonusPunktKonzept { get; set; }
		//[DataMember]
		public long BonusPunktTausch { get; set; }
		//[DataMember]
		public long BonusPunktLiefer { get; set; }



		public Guid OfflineId { get; set; }
		public int OfflineStatus { get; set; }

		public bsBestellung()
		{

		}

		public bsBestellung(SerializationInfo info, StreamingContext ctxt)
		{
			// Hier deserialisieren...
			var values = info.GetEnumerator();

			while (values.MoveNext())
			{

				switch (values.Name)
				{
					case "Kundennummer":
					case "<Kundennummer>k__BackingField":
						Kundennummer = values.Value as string;
						break;
					case "BestellnotizAngabe":
					case "<BestellnotizAngabe>k__BackingField":
						BestellnotizAngabe = values.Value as string;
						break;
					case "Lieferzeitpunkt":
					case "<Lieferzeitpunkt>k__BackingField":
						Lieferzeitpunkt = values.Value as string;
						break;
					case "BestellnotizBestellnummer":
					case "<BestellnotizBestellnummer>k__BackingField":
						BestellnotizBestellnummer = values.Value as string;
						break;
					case "Id":
					case "<Id>k__BackingField":
						Id = (Guid)values.Value;
						break;
					case "PraesentationsBBS":
					case "<PraesentationsBBS>k__BackingField":
						PraesentationsBBS = (bool)values.Value;
						break;
					case "HandelspartnerBBS":
					case "<HandelspartnerBBS>k__BackingField":
						HandelspartnerBBS = (bool)values.Value;
						break;
					case "Lieferart":
					case "<Lieferart>k__BackingField":
						Lieferart = (Liefermodi)values.Value;
						break;
					case "Profilname":
					case "<Profilname>k__BackingField":
						Profilname = values.Value as string;
						break;
					case "Lieferantenname":
					case "<Lieferantenname>k__BackingField":
						Lieferantenname = values.Value as string;
						break;
					case "Benutzername":
					case "<Benutzername>k__BackingField":
						Benutzername = values.Value as string;
						break;
					case "BestellId":
					case "_BestellID":
						BestellId = (long)values.Value;
						break;
					case "OfflineBestellId":
					case "_OfflineBestellID":
						OfflineBestellId = (string)values.Value;
						break;
					case "ResponseID_ValidateWarenkorb":
					case "<ResponseID_ValidateWarenkorb>k__BackingField":
						ResponseID_ValidateWarenkorb = (long)values.Value;
						break;
					case "ResponseID_PerformBestellung":
					case "<ResponseID_PerformBestellung>k__BackingField":
						ResponseID_PerformBestellung = (long)values.Value;
						break;
					case "Firmenname":
					case "<Firmenname>k__BackingField":
						Firmenname = values.Value as string;
						break;
					case "FirmenAdresszusatz":
					case "<FirmenAdresszusatz>k__BackingField":
						FirmenAdresszusatz = values.Value as string;
						break;
					case "VersandadresseStrasse":
					case "<VersandadresseStrasse>k__BackingField":
						VersandadresseStrasse = values.Value as string;
						break;
					case "VersandadressePlz":
					case "<VersandadressePlz>k__BackingField":
						VersandadressePlz = values.Value as string;
						break;
					case "VersandadresseOrt":
					case "<VersandadresseOrt>k__BackingField":
						VersandadresseOrt = values.Value as string;
						break;
					case "StandortName":
					case "<StandortName>k__BackingField":
						StandortName = values.Value as string;
						break;
					case "StandortStrasse":
					case "<StandortStrasse>k__BackingField":
						StandortStrasse = values.Value as string;
						break;
					case "StandortPlz":
					case "<StandortPlz>k__BackingField":
						StandortPlz = values.Value as string;
						break;
					case "StandortOrt":
					case "<StandortOrt>k__BackingField":
						StandortOrt = values.Value as string;
						break;
					case "StandortTel":
					case "<StandortTel>k__BackingField":
						StandortTel = values.Value as string;
						break;
					case "StandortFax":
					case "<StandortFax>k__BackingField":
						StandortFax = values.Value as string;
						break;
					case "WarenkorbSumme":
					case "<WarenkorbSumme>k__BackingField":
						WarenkorbSumme = (decimal)values.Value;
						break;
					case "NachtexpressVorhanden":
					case "<NachtexpressVorhanden>k__BackingField":
						NachtexpressVorhanden = (bool)values.Value;
						break;
					case "GesamtBonuswert":
					case "<GesamtBonuswert>k__BackingField":
						GesamtBonuswert = (long)values.Value;
						break;
					case "ShowBonus":
					case "<ShowBonus>k__BackingField":
						ShowBonus = (bool)values.Value;
						break;
					case "ShowPreise":
					case "<ShowPreise>k__BackingField":
						ShowPreise = (bool)values.Value;
						break;
					case "KontoStand":
					case "<KontoStand>k__BackingField":
						KontoStand = (long)values.Value;
						break;
					case "Bestellzeit":
					case "_Bestellzeit":
						Bestellzeit = (DateTime)values.Value;
						break;
					case "Waehrung":
					case "<Waehrung>k__BackingField":
						Waehrung = values.Value as string;
						break;
					case "Auftragsnummer":
					case "<Auftragsnummer>k__BackingField":
						Auftragsnummer = values.Value as string;
						break;
					case "FileName":
					case "<FileName>k__BackingField":
						FileName = values.Value as string;
						break;
					case "Positionen":
					case "<Positionen>k__BackingField":
						Positionen = values.Value as List<bsPosition>;
						break;
					case "Filename":
					case "<Filename>k__BackingField":
						Filename = values.Value as string;
						break;
					case "Bestellstatus":
					case "_Bestellstatus":
						Bestellstatus = values.Value as string;
						break;
					case "BonusPunktUmsatz":
					case "<BonusPunktUmsatz>k__BackingField":
						BonusPunktUmsatz = (long)values.Value;
						break;
					case "BonusPunktAktion":
					case "<BonusPunktAktion>k__BackingField":
						BonusPunktAktion = (long)values.Value;
						break;
					case "BonusPunktKompassBestellBonus":
					case "<BonusPunktKompassBestellBonus>k__BackingField":
						BonusPunktKompassBestellBonus = (long)values.Value;
						break;
					case "BonusPunktTausch":
					case "<BonusPunktTausch>k__BackingField":
						BonusPunktTausch = (long)values.Value;
						break;
					case "BonusPunktLiefer":
					case "<BonusPunktLiefer>k__BackingField":
						BonusPunktLiefer = (long)values.Value;
						break;
					case "BonusPunktKonzept":
					case "<BonusPunktKonzept>k__BackingField":
						BonusPunktKonzept = (long)values.Value;
						break;
					//case "OfflineId":
					//    if( values!= null && values.Value != null)
					//        OfflineId = (Guid)values.Value;
					//    break;
					case "OfflineStatus":
						if (values != null && values.Value != null)
							OfflineStatus = (int)values.Value;
						break;

					default:
						break;
				}
			}
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			try
			{
				info.AddValue("Kundennummer", Kundennummer);
				info.AddValue("BestellnotizAngabe", BestellnotizAngabe);
				info.AddValue("Lieferzeitpunkt", Lieferzeitpunkt);
				info.AddValue("BestellnotizBestellnummer", BestellnotizBestellnummer);
				info.AddValue("Id", Id);
				info.AddValue("PraesentationsBBS", PraesentationsBBS);
				info.AddValue("HandelspartnerBBS", HandelspartnerBBS);
				info.AddValue("Lieferart", Lieferart);
				info.AddValue("Profilname", Profilname);
				info.AddValue("Lieferantenname", Lieferantenname);
				info.AddValue("Benutzername", Benutzername);
				info.AddValue("BestellId", BestellId);
				info.AddValue("OfflineBestellId", OfflineBestellId);
				info.AddValue("ResponseID_ValidateWarenkorb", ResponseID_ValidateWarenkorb);
				info.AddValue("ResponseID_PerformBestellung", ResponseID_PerformBestellung);
				info.AddValue("Firmenname", Firmenname);
				info.AddValue("FirmenAdresszusatz", FirmenAdresszusatz);
				info.AddValue("VersandadresseStrasse", VersandadresseStrasse);
				info.AddValue("VersandadressePlz", VersandadressePlz);
				info.AddValue("VersandadresseOrt", VersandadresseOrt);
				info.AddValue("StandortName", StandortName);
				info.AddValue("StandortStrasse", StandortStrasse);
				info.AddValue("StandortPlz", StandortPlz);
				info.AddValue("StandortOrt", StandortOrt);
				info.AddValue("StandortTel", StandortTel);
				info.AddValue("StandortFax", StandortFax);
				info.AddValue("WarenkorbSumme", WarenkorbSumme);
				info.AddValue("NachtexpressVorhanden", NachtexpressVorhanden);
				info.AddValue("GesamtBonuswert", GesamtBonuswert);
				info.AddValue("ShowBonus", ShowBonus);
				info.AddValue("ShowPreise", ShowPreise);
				info.AddValue("KontoStand", KontoStand);
				info.AddValue("Bestellzeit", Bestellzeit);
				info.AddValue("Waehrung", Waehrung);
				info.AddValue("Auftragsnummer", Auftragsnummer);
				info.AddValue("FileName", FileName);
				info.AddValue("Positionen", Positionen);
				info.AddValue("Filename", Filename);
				info.AddValue("Bestellstatus", Bestellstatus);
				info.AddValue("BonusPunktUmsatz", BonusPunktUmsatz);
				info.AddValue("BonusPunktAktion", BonusPunktAktion);
				info.AddValue("BonusPunktKompassBestellBonus", BonusPunktKompassBestellBonus);
				info.AddValue("BonusPunktTausch", BonusPunktTausch);
				info.AddValue("BonusPunktLiefer", BonusPunktLiefer);
				info.AddValue("BonusPunktKonzept", BonusPunktKonzept);
				//info.AddValue("OfflineId", OfflineId);
				info.AddValue("OfflineStatus", OfflineStatus);
			}
			catch (Exception)
			{

			}
		}
	}

	public class BestellBestaetigungsInfo
	{
		public BestellBestaetigungsInfo()
		{
			Bestellliste = new List<bsBestellung>();
			Bestellarten = new List<Bestellart>();
		}

		public List<bsBestellung> Bestellliste { get; set; }

		public DateTime BestellungMaxDate { get; set; }

		public DateTime BestellungMinDate { get; set; }

		public int GesamtanzahlElemente { get; set; }

		public List<Bestellart> Bestellarten { get; set; }
	}

	public class Bestellart
	{
		public string Displayname { get; set; }

		public string KeyValue { get; set; }
	}

	public class BestellBestaetigungRequest
	{
		public int ProfilId { get; set; }

		public DateTime MinDate { get; set; }

		public DateTime MaxDate { get; set; }

		public string Suchtext { get; set; }

		public string Bestellart { get; set; }

		public bool? Praesentation { get; set; }

		public int Startindex { get; set; }

		public int AnzahlElemente { get; set; }
	}

    public class GetBestellungRequest
    {
        public int Id { get; set; }
        public bool ShowVkPreise { get; set; }
        public bool ShowEkPreise { get; set; }
    }
}
