/************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Holger Huckfeldt   
 * Modul:    Artikel-Identifikation   
 * Funktionen:  Kapselt die Artikeldetailinfos
 ***********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PV.DomainObjects.Artikel
{

    [DataContract]
    [Serializable]
    public class ArtikelDetailContainer
    {
        [DataMember]
        public List<KeyValuePair<String, String>> Logistik
        {
            get; set;
        }

        [DataMember]
        public List<ArtikelDokument> Dokumente
        {
            get; set;
        }

        [DataMember]
        public NummernTransport Nummern
        {
            get; set;
        }

        [DataMember]
        public GefahrengutHinweise Gefargen
        {
            get; set;
        }
    }
}
