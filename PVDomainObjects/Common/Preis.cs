/**************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Torsten Gaul  
 * Modul:    Stammdaten   
 * Funktionen: Kapselt die Informationen und die Funktionen eines Preises
 *************************************************************************/
using System;


namespace PV.DomainObjects.Common
{
    /// <summary>
    /// Kapselt die PreisInformationen eines Eigenen Artikels
    /// </summary>
    [Serializable]
    public class Preis
    {
        #region fields

        private Guid _Id;
        private double _EKPreis;
        private double _VKPreis_Netto;
        private double _MwSt;
        private UStArt _UStArt;

        #endregion

        #region Props

        /// <summary>
        /// Id des Preises
        /// </summary>
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// EK Preis des Eigenen Artikels
        /// </summary>
        public double EKPreis
        {
            get { return _EKPreis; }
            set { _EKPreis = value; }
        }

        /// <summary>
        /// Netto VK Preis des Eigenen Artikels
        /// </summary>
        public double VKPreis_Netto
        {
            get { return _VKPreis_Netto; }
            set { _VKPreis_Netto = value; }
        }

        /// <summary>
        /// Die zugrunde liegende Mehrwert Steuer des Eigenen Artikels
        /// </summary>
        public double MwSt
        {
            get { return _MwSt; }
            set { _MwSt = value; }
        }

        public double VKPreis_Brutto
        {
            get
            {
                double dMwst = ((MwSt / 100) + 1);
                return Math.Round(dMwst * _VKPreis_Netto, 2);
            }
        }

        public UStArt UStArt
        {
            get { return _UStArt; }
            set { _UStArt = value; }
        }

        #endregion

        public Preis()
        { 
        }

        public Preis(Guid _id)
        {
            Id = _id;
        }
    }
}
