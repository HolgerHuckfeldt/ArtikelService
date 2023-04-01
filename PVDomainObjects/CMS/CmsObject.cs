/***************************************************************************************************
 * Copyright Absolute Software GmbH 2010
 * Projekt:  PV-Kompass 
 * Author:   Björn Schönwolff
 * Modul:    CMSBackend
 * Funktionen:  Repräsentiert ein CMS Datenobjekt  
 **************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PV.DomainObjects.CMS
{
    [DataContract]
    public class CmsObject
    {
        #region Fields

        #endregion

        #region Properties

        [DataMember]
        public int ProfilId { get; set; }

        [DataMember]
        public List<int> KKZ { get; set; }

        [DataMember]
        public CMS_Modul Modul { get; set; }

        [DataMember]
        public CMS_Modulbox Modulbox { get; set; }

        [DataMember]
        public int ModulboxIndex { get; set; }

        [DataMember]
        public CMS_Inhaltstyp Inhaltstyp { get; set; }

        [DataMember]
        public byte[] Inhalt { get; set; }

        [DataMember]
        public bool Gueltigkeit { get; set; }

        [DataMember]
        public DateTime GueltigVon { get; set; }

        [DataMember]
        public DateTime GueltigBis { get; set; }

        [DataMember]
        public string Referenz { get; set; }

        [DataMember]
        public string NameCMSSetting { get; set; }
        
        public string Pfad
        {
            get
            {
                return String.Format("{0}/{1}/{2}",
                    Enum.GetName(typeof(CMS_Modul), Modul),
                    Enum.GetName(typeof(CMS_Modulbox), Modulbox),
                    ModulboxIndex
                    );
            }
        }

        [DataMember]
        public string CMSSettingName { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Value2 { get; set; }

        #endregion

        #region Enums

        [DataContract]
        public enum CMS_Modul
        {
            [EnumMember]
            Kompass = 0,
            [EnumMember]
            Plus = 1,
            [EnumMember]
            Training = 2,
            [EnumMember]
            PVApp = 3
        }

        [DataContract]
        public enum CMS_Modulbox
        {
            [EnumMember]
            KompassAktuellUndWichtig = 0,
            [EnumMember]
            B2BOAktuellUndWichtig = 11,
            [EnumMember]
            KompassHeaderText = 1,
            [EnumMember]
            B2BOHeaderText = 10,
            [EnumMember]
            B2BOBildStartseite = 12,
            [EnumMember]
            KompassBenutzerPlus = 2,
            [EnumMember]
            PlusStartseite = 3,
            [EnumMember]
            PlusIhreVorteile = 4,
            [EnumMember]
            TrainingWillkommen = 5,
            [EnumMember]
            TrainingUeberTraining = 6,
            [EnumMember]
            TrainingNochFragen = 7,
            [EnumMember]
            TrainingAnmeldungUndStorno = 8,
            [EnumMember]
            KompassIncentive = 9,
            [EnumMember]
            MobileAktuellUndWichtig = 13,
            [EnumMember]
            UpgradePlusBronze = 14,
            [EnumMember]
            TrainingAktuellUndWichtig = 15,
            [EnumMember]
            PlusAktuellUndWichtig = 16,
            [EnumMember]
            PVAppBilder = 17,
            [EnumMember]
            KKZAktuellUndWichtig = 18
        }

        [DataContract]
        public enum CMS_Inhaltstyp
        {
            [EnumMember]
            Bild = 0,
            [EnumMember]
            Freitext = 1,
            [EnumMember]
            Sidebar = 2,
            [EnumMember]
            Link = 3,
            [EnumMember]
            BildKKZ = 4
        }

        #endregion
    }


}
