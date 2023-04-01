/******************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Manfred Tropper  
 * Modul:    Modulübergreifend
 * Funktionen:  Beschreibt die Schnittstelle welche ein Bereichs-Printmanager implementieren
 *              muss, um den Printmanager mit gültigen Daten zu versorgen
 ******************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PV.Printing
{
    public interface IPVPrintingStrategy
    {
        string Title { get; set; }
    }
}
