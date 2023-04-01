/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Artikel-Identifikation   
 * Funktionen:  Kapselt die Informationen und Funktionen eines Artikels
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace PV.DomainObjects.Artikel
{

    /// <summary>
    /// TecCom Infos. 
    /// </summary>
    [DataContract]
    [Serializable]
    public class TecComInfo
    {
        [DataMember]
        public int ConfirmedQuantity;
        [DataMember]
        public int RequestedQuantity;
        [DataMember]
        public string ProductNumber;
        [DataMember]
        public string DeliveryArticleNumber;
        [DataMember]
        public string DeliveryArticleHlk;
    }
}
