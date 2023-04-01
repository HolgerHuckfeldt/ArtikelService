/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Walter Licht
 * Modul:       Image Provider Technikbilder
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die Technikbilder Lieferung erfüllen muss
 *********************************************************************************************************/

using System;
using System.Collections.Generic;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// ImageProvider liefert Bilder als Object, diese lassen sich dann als Image oder Viewbox Casten
    /// </summary>
    public interface IImageProvider
    {
        /// <summary>
        /// Liefert ein Gif Image, die URI muss nur Teilqualifiziert sein
        /// bsp. "autoteil" anstatt "gif\\autoteil.gif"
        /// </summary>
        /// <param name="_uri"></param>
        /// <returns></returns>
        Object LoadImageGif(String _uri);

        /// <summary>
        /// Liefert ein Jpeg Image, die URI muss nur Teilqualifiziert sein
        /// bsp. "autoteil" anstatt "jpg\\autoteil.jpg"
        /// </summary>
        /// <param name="_uri"></param>
        /// <returns></returns>
        Object LoadImageJpeg(String _uri);

        /// <summary>
        /// Liefert ein Xaml Image, die URI muss nur Teilqualifiziert sein
        /// bsp. "autoteil" anstatt "xaml\\autoteil.xaml"
        /// </summary>
        /// <param name="_uri"></param>
        /// <returns></returns>
        Object LoadImageXaml(String _uri);

        /// <summary>
        /// Liefert ein Gif Image, die URI muss VOLLqualifiziert sein
        /// bsp. "gif\\autoteil.gif"
        /// </summary>
        /// <param name="_uri"></param>
        /// <returns></returns>
        Object LoadImageAny(String _uri);
    }
}