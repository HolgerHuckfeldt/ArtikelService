using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PV.DomainObjects.Wartung.TransferObjects
{
    /// <summary>
    /// Stellt ein Transferobjekt für WartungsObjekte des TKD Zips dar
    /// </summary>
    [DataContract]
    [Serializable]
    public class MaintenanceTo
    {
        #region Properties

        /// <summary>
        /// "Baujahr von" für den diese Wartugng gilt
        /// </summary>
        [DataMember]
        public int BaujahrVon
        {
            get;
            set;
        }

        /// <summary>
        /// "Baujahr bis" für den diese Wartugng gilt
        /// </summary>
        [DataMember]
        public int BaujahrBis
        {
            get;
            set;
        }

        /// <summary>
        /// Motorcode für den diese Wartugng gilt
        /// </summary>
        [DataMember]
        public string Motorcode
        {
            get;
            set;
        }

        /// <summary>
        /// Wahr wenn der AW-Wert geschätzt ist
        /// </summary>
        [DataMember]
        public bool AwGeschaetzt
        {
            get;
            set;
        }

        [DataMember]
        private IList<MaintenanceSentenceTo> _maintenanceSentenceListe;

        /// <summary>
        /// Liste der Wartungspositionen
        /// </summary>
        public IList<MaintenanceSentenceTo> MaintenanceSentenceListe
        {
            get
            {
                return _maintenanceSentenceListe ?? (_maintenanceSentenceListe = new List<MaintenanceSentenceTo>());
            }
        }

        /// <summary>
        /// Die original Vivid maint_period_id
        /// </summary>
        [DataMember]
        public int VividMaintPeriodId
        {
            get;
            set;
        }

        /// <summary>
        /// Die original Vivid maint_periods_sentence_id
        /// </summary>
        [DataMember]
        public int VividMaintPeriodSentenceId
        {
            get;
            set;
        }

        /// <summary>
        /// Die original Vivid maint_system_id
        /// </summary>
        [DataMember]
        public int VividMaintSystemId
        {
            get;
            set;
        }

        /// <summary>
        /// TecDoc motnr für die diese Wartugng gilt
        /// </summary>
        [DataMember]
        public int MotorNummer
        {
            get;
            set;
        }

        /// <summary>
        /// Periodenbeschreibung
        /// </summary>
        [DataMember]
        public string PeriodenText
        {
            get;
            set;
        }

        /// <summary>
        /// Systembeschreibung 
        /// </summary>
        [DataMember]
        public string SystemText
        {
            get;
            set;
        }


        /// <summary>
        /// Ist es kombinierbar 
        /// </summary>
        [DataMember]
        public bool IsCombine
        {
            get;
            set;
        }


        /// <summary>
        /// Gesamt AW-Wert der Wartung 
        /// </summary>
        [DataMember]
        public double AwWert
        {
            get;
            set;
        }

        /// <summary>
        /// Gesamt AW-Wert der Wartung in Stunden 
        /// </summary>
        [DataMember]
        public double AwStunden
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt an ob es sich um ein Meilen-System handelt 
        /// </summary>
        [DataMember]
        public bool Meilen
        {
            get;
            set;
        }

        [DataMember]
        public bool IsCombined
        {
            get; 
            set;
        }

        [DataMember]
        public bool ArbeitsProzessLoaded
        {
            get;
            set;
        }

        #endregion

        public MaintenanceTo()
        {
            ArbeitsProzessLoaded = false;
        }

    }
}
