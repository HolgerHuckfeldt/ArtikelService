/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz   
* Modul:    KVA
* Funktionen: Beschreibt das Interface eines KVAPositionsCalculators 
*****************************************************************************************************/

namespace PVInterfaces.Strategien
{
    /// <summary>
    /// Beschreibt das Interface eines KVAPositionsCalculators
    /// </summary>
    public interface IKVAPositionsCalculatorStrategy
    {
        /// <summary>
        /// Kalkuliert den Einzel-Netto-VK-Preis einer KVA Position
        /// </summary>
        /// <param name="_ekOriginal">Der Einzel-Netto-EK-Preis</param>
        /// <param name="_leistungdRabat">Der LeistungsRabatt</param>
        /// <param name="_materialRabat">Der Materialrabatt</param>
        /// <returns></returns>
        decimal CalculateByRabatt( decimal _ekOriginal, decimal _leistungdRabat, decimal _materialRabat );

        /// <summary>
        /// Kalkuliert den Einzel-Netto-VK-Preis einer KVA Position
        /// </summary>
        /// <param name="_ekOriginal">Der Einzel-Netto-EK-Preis</param>
        /// <param name="_marge">Die Marge</param>
        /// <returns></returns>
        decimal CalculateByMarge( decimal _ekOriginal, decimal _marge );
    }
}
