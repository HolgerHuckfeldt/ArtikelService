/*********************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:      
 * Modul:       
 * Funktionen:  
 *********************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PV.DomainObjects.Artikel;

namespace PVInterfaces.Services.Persistance
{

    public enum TemotType
    {
        EX = 1,
        SP = 2,
        EMS = 3
    }

    public interface ITemotProvider
    {
        /// <summary>
        /// Holt ein (dynamisch erzeugtes) Bildchen 
        /// </summary>
        /// <param name="stripid"></param>
        /// <param name="carid"></param>
        /// <param name="steering"></param>
        /// <param name="width"></param>
        /// <param name="hotspot"></param>
        /// <returns></returns>
        Stream GetTemotGraphic(string stripid, string carid, TemotType ttype, int width, bool hotspot);

        /// <summary>
        /// Holt ein Bild, das als Uri identifiziert ist.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Stream GetTemotGraphic(string uri);

        /// <summary>
        /// Holt für einen TecDoc-PkwType die dazugehörigen Temot-Typen und Strips als ISuchbaumeinträge.
        /// </summary>
        /// <param name="pkwtype"></param>
        /// <returns></returns>
        List<SuchbaumEintrag> GetSuchbaumEintragList(int pkwtype, TemotType ttype, int startindex);

    }
}
