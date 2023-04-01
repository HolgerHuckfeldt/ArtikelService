/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Walter Licht
 * Modul:    Artikel-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Artikels
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PV.DomainObjects.Arbeitswerte;
using PV.DomainObjects.Common;
using PV.DomainObjects.Fahrzeug;


namespace PV.DomainObjects.Artikel
{
    [DataContract]
    [Serializable]
    public enum GebrauchsmusterArt
    {
        [EnumMember]
        Pkw,

        [EnumMember]
        Nkw,

        [EnumMember]
        Motor,

        [EnumMember]
        Achse
    }
}
