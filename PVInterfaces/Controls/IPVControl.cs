/******************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Björn Schönwolff   
 * Modul:    Modulübergreifend
 * Funktionen:  Beschreibt die Schnittstelle welche ein Control erfüllen muss um mit dem BusinessLayer zusammen zu arbeiten
 *              Muss überarbeitet werden, damit eine URI statt eines Managers (hier noch Provider) zugewiesen werden kann.
 ******************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.Controls
{
    //TODO: Björn Überarbeiten
    /// <summary>
    /// Beschreibt die Schnittstelle welche ein Control erfüllen muss um mit dem BusinessLayer zusammen zu arbeiten
    /// </summary>
    public interface IPVControl
    {
        //PV.Business.Services.IBusinessManager PvServiceProvider { set; }
    }
}
