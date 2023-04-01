/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikelsuche
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Artikel erfüllen muss
 ***************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;
using PV.DomainObjects.CMS;
using PVInterfaces.Enums;

namespace PV.Persistance.Provider
{
    
    /// <summary>
    /// Abstrahiert die Schnittstelle welche ein Provider für Artikel erfüllen muss
    /// </summary>
    public interface IMobilePersistanceProvider
    {

        #region Artikel

        /// <summary>
        /// Liefert eine Liste aller Suchbaumeinträge in einer angegebenen Sprache
        /// </summary>
        /// <param name="_art">Die Angabe welcher Suchbaum gewünscht ist</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_typ"></param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <returns>Liste von SuchbaumEintrag</returns>
        
        List<SuchbaumEintrag> GetSuchbaumEintragList(string profile, string art, int typ);

        
        List<MobileArtikel> GetArtikelListBySuchknotenAndType(string profile, string art, int knoten, int typ);

        /// <summary>
        /// Liefert die Artikelliste anhand eines Suchbaumeintrages für einen Typen in einer angegebenen Sprache
        /// </summary>
        /// <param name="_art">Die Angabe für was man Artikel sucht</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_toSearch">Der zu suchende String</param>
        /// <param name="_typ">Der Typ</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste von Artikeln</returns>
        
        List<MobileArtikel> GetArtikelListeBySuchstring(string profile, SuchstringAndTyp requestdata);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren OE-Nummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        List<MobileArtikel> GetArtikelByReferenzNummer(string profile, ArtikelNummernsucheArten requestdata);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren EA-Nummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        List<MobileArtikel> GetArtikelByEAN(string profile, ArtikelNummernsucheArten requestdata);


        /// <summary>
        /// Liefert eine Liste von Artikeln, deren Artikelnummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        List<MobileArtikel> GetArtikelByArtikelNummer(string profile, ArtikelNummernsucheArten requestdata);

        
        List<MobileArtikel> GetArtikelByArtikelNummerFreetext(string profile, ArtikelNummernsucheArten requestdata);


        /// <summary>
        /// Liefert eine Liste von Artikeln, deren Gebrauchsnummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        List<MobileArtikel> GetArtikelByGebrauchsNummer(string profile, ArtikelNummernsucheArten requestdata);

        /// <summary>
        /// Liefert eine Liste von Artikeln, deren Vergleichsnummern einen bestimmten String enthalten
        /// </summary>
        /// <param name="_nummer">Die Nummer nach der gesucht werden soll</param>
        /// <param name="_mandant">Der Mandant in einem Mehrmandantensystem</param>
        /// <param name="_lang">Die Id der gewünschten Sprache</param>
        /// <param name="_firma">Die Firmen-Id des Kunden</param>
        /// <param name="_standort">Die Standort-Id des Kunden</param>
        /// <param name="_abteilung">Die Abteilungs-Id des Kunden</param>
        /// <param name="_kundengruppe">Kundengruppen-Id des Kunden</param>
        /// <param name="_absatzgruppe">Absatzgruppen-Id des Kunden</param>
        /// <param name="_pluskunde">Ist der Kunde ein Plus-Kunde</param>
        /// <returns>Liste der zusätzlichen Artikel</returns>
        
        List<MobileArtikel> GetArtikelByVergleichsNummer(string profile, ArtikelNummernsucheArten requestdata);

        
        MobileArtikelDetails GetArtikelDetails(string profile, MobileArtikelDetailsRequest requestdata);

        
        List<MobileArtikel> GetArtikelByArtikelIdList(string profile, List<int> listOfArtikelIds);

        #endregion

        #region pkw

        /// <summary>
        /// Initialisiert das Laden der Liste aller Hersteller
        /// </summary>
        
        IList<Hersteller> LoadHerstellerList();

        /// <summary>
        /// Initialisiert das Laden der Liste aller Modelle eines Herstellers
        /// </summary>
        /// <param name="hersteller">Objekt mit Suchinformationen</param>
        
        IList<Modell> LoadModellList(Hersteller hersteller);

        
        IList<PKWTyp> LoadPKWTypList(Modell model);

        
        IList<PKWTyp> LoadPKWTypListByString(string toSearch);

        
        IList<PKWTyp> LoadPKWTypListByKType(int ktype);

        #endregion

        #region cms

        
        CmsObject LoadContent(CmsObject entry);

        #endregion

        #region Login

        
        string TryLogin(string id);

        
        string TryLoginEinlogDeviceTyp(string id, EinlogDeviceTyp einlogDeviceTyp);

        #endregion
    }
}
