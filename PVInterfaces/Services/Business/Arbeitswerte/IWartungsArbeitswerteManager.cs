/*****************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    WartungsArbeitswerte
 * Funktionen: Abstrahiert die Schnittstelle des WartungsArbeitswertmanagers  und definiert seine Delegates 
*****************************************************************************************************/


using PV.DomainObjects.Technik;
namespace PV.Business.Services
{
    
    /// <summary>
    /// Beschreibt die Schnittstelle, welche ein Manager für WartungsArbeitswerte erfüllen muss
    /// </summary>
    public interface IWartungsArbeitswertManager : IArbeitswerteBaseManager
    {
        /// <summary>
        /// Setzt und liefert den FahrzeugTyp.
        /// </summary>
        Fahrzeug AktuellesFahrzeug
        {
            get;
        }

        /// <summary>
        /// Setzt das aktuelle Fahrzeug anhand
        /// einen Vivid Type-ID
        /// </summary>
        /// <param name="typeid"></param>
        void SetAktuellesFahrzeugByTypeId(int typeid);

        /// <summary>
        /// Setzt das Akteulle Fahrzeug.
        /// </summary>
        void SetAktuellesFahrzeug(Fahrzeug fahrzeug);
    }
}