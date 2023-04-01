using System;
using PVInterfaces.Strategien;

namespace PV.DomainObjects.KVA
{
    [Serializable]
    public class KVAMaterialCalculator : IKVAPositionsCalculatorStrategy
    {
        #region Implementation of IKVAPositionsCalculatorStrategy

        /// <summary>
        /// Kalkuliert den Einzel-Netto-VK-Preis einer KVA Position
        /// </summary>
        /// <param name="_ekOriginal">Der Einzel-Netto-EK-Preis</param>
        /// <param name="_leistungdRabat">Der LeistungsRabatt</param>
        /// <param name="_materialRabat">Der Materialrabatt</param>
        /// <returns></returns>
        public decimal CalculateByRabatt( decimal _ekOriginal, decimal _leistungdRabat, decimal _materialRabat )
        {
            return _ekOriginal - _materialRabat;
        }

        /// <summary>
        /// Kalkuliert den Einzel-Netto-VK-Preis einer KVA Position
        /// </summary>
        /// <param name="_ekOriginal">Der Einzel-Netto-EK-Preis</param>
        /// <param name="_marge">Die Marge</param>
        /// <returns></returns>
        public decimal CalculateByMarge( decimal _ekOriginal, decimal _marge )
        {
            return _ekOriginal + _marge;
        }

        #endregion
    }
}
