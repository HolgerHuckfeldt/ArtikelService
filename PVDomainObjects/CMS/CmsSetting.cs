/***************************************************************************************************
 * Copyright Absolute Software GmbH 2010
 * Projekt:  PV-Kompass 
 * Author:   Björn Schönwolff
 * Modul:    CMSBackend
 * Funktionen:  Repräsentiert ein CMS Setting  
 **************************************************************************************************/

using System.Runtime.Serialization;
using System;

namespace PV.DomainObjects.CMS
{
    [DataContract]
    public class CmsSetting
    {
        #region Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Value { get; set; }

        #endregion
    }
}
