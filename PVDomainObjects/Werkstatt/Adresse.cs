/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz  
 * Modul:    Stammdatenverwaltung   
 * Funktionen:  Kapselt die Informationen einer Adresse
 ************************************************************************************/
using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace PV.DomainObjects.Stammdaten
{
	/// <summary>
	/// Kapselt die Informationen einer Adresse
	/// </summary>
	[DataContract]
	[Serializable]
	public class Adresse
	{
		#region Fields

		private string _Ort = string.Empty;
		private string _PLZ = string.Empty;
		private string _Strasse = string.Empty;
		private string _StrasseUndNummer = string.Empty;
		private string _Strassenname = string.Empty;
		private string _Hausnummer = string.Empty;
		private string _Email = string.Empty;
		private string _Telefon1 = string.Empty;
		private string _Vorwahl1 = string.Empty;
		private string _Telefon2 = string.Empty;
		private string _Vorwahl2 = string.Empty;
		private string _Fax = string.Empty;
		private string _FaxVorwahl = string.Empty;

		#endregion


		/// <summary>
		/// Konstruktor der Klasse
		/// </summary>
		public Adresse()
		{
			Id = Guid.NewGuid();
		}

		#region Properties

		/// <summary>
		/// Liefert und setzt die Guid in der Datenquelle
		/// </summary>
		[DataMember]
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		/// Liefert und setzt den Ort
		/// </summary>
		[DataMember]
		public string Ort
		{
			get
			{
				return _Ort;
			}
			set
			{
				_Ort = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die PLZ zum Ort
		/// </summary>
		[DataMember]
		public string PLZ
		{
			get
			{
				return _PLZ;
			}
			set
			{
				_PLZ = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Strasse
		/// </summary>
		[DataMember]
		public string Strasse
		{
			get
			{
				return _Strasse;
			}
			set
			{
				_Strasse = value;
			}
		}

		[DataMember]
		public string Strassenname
		{
			get
			{
				if (string.IsNullOrEmpty(_Strassenname))
				{
					return _Strasse;
				}
				return _Strassenname;
			}
			set
			{
				_Strassenname = value;
			}
		}

		[DataMember]
		public string Hausnummer
		{
			get
			{
				if (string.IsNullOrEmpty(_Hausnummer))
				{
					return string.Empty;
				}
				return _Hausnummer;
			}
			set
			{
				_Hausnummer = value;
			}
		}
		
		
		/// <summary>
		/// Liefert und setzt die Mailadresse
		/// </summary>
		[DataMember]
		public string Email
		{
			get
			{
				return _Email;
			}
			set
			{
				_Email = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die erste Telefonnummer
		/// </summary>
		[DataMember]
		public string Telefon1
		{
			get
			{
				return _Telefon1;
			}
			set
			{
				_Telefon1 = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Vorwahl zur ersten Telefonnummer
		/// </summary>
		[DataMember]
		public string Vorwahl1
		{
			get
			{
				return _Vorwahl1;
			}
			set
			{
				_Vorwahl1 = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die zweite Telefonnummer
		/// </summary>
		[DataMember]
		public string Telefon2
		{
			get
			{
				return _Telefon2;
			}
			set
			{
				_Telefon2 = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Vorwahl zur zweiten Telefonnummer
		/// </summary>
		[DataMember]
		public string Vorwahl2
		{
			get
			{
				return _Vorwahl2;
			}
			set
			{
				_Vorwahl2 = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Faxnummer
		/// </summary>
		[DataMember]
		public string Fax
		{
			get
			{
				return _Fax;
			}
			set
			{
				_Fax = value;
			}
		}

		/// <summary>
		/// Liefert und setzt die Vorwahl zur Faxnummer
		/// </summary>
		[DataMember]
		public string FaxVorwahl
		{
			get
			{
				return _FaxVorwahl;
			}
			set
			{
				_FaxVorwahl = value;
			}
		}

		#endregion

		public static void ParseStrasseUndNummer(string strasseundnummer, out string strassenname, out string hausnummer)
		{
			strassenname = string.Empty;
			hausnummer = string.Empty;

			// Dieser Parser berücksichtigt korrekt formatierte Adressen der Form:
			// Strasse 123
			// Strasse 123-124
			// Strasse 123 - 124
			// Strasse 123A
			// Strasse 123 A
			// Strasse 123A-E
			// Strasse 123 A-E

			// alles andere muß der Benutzer manuell eingeben/korrigieren

			if (string.IsNullOrEmpty(strasseundnummer)) return;

			string n = strasseundnummer;
			// ein bißchen aufräumen
			n = n.Replace(".", ". ");
			string[] parts = n.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			Regex r = new Regex(
				   @"\s(\d+\s?-\s?\d+)$"		// 123-124
				+ @"|\s(\d+\s?\D)$"				// 123A
				+ @"|\s(\d+\s?\D\s?-\s?\D)$"	// 123A-E
				+ @"|\s(\d+)$"					// 123
			);

			Match m = r.Match(n);
			if (m != null && m.Captures.Count > 0)
			{
				hausnummer = m.Value.Trim();
				if (strasseundnummer.EndsWith(hausnummer))
				{
					strassenname = strasseundnummer.Substring(0, strasseundnummer.Length - hausnummer.Length).Trim();
				}
				else
				{
					hausnummer = string.Empty;
				}
			}
		}
	}
}
