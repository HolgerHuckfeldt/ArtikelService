/*******************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Modulübergreifend   
 * Funktionen:  Beschreibt die Schnittstelle eines Items, welches man in den KVA legen kann
 ******************************************************************************************/

using System.Runtime.Serialization;

namespace PV.DomainObjectInterfaces
{
    /// <summary>
    /// Beschreibt die Schnittstelle eines Items, welches man in den KVA legen kann
    /// </summary>
    public interface IKVAItem
    {
    }

    [DataContract]
    public enum WaWiMode
    {
        [EnumMember]
        RepDoc = 0,
        [EnumMember]
        Beracom = 1,
        [EnumMember]
        Generic = 2,
        [EnumMember]
        BeracomNew = 3,
        [EnumMember]
        RepDocNew = 4
    } ;

}
