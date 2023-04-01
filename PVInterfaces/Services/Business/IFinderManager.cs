/*********************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Dirk Lannatewitz   
 * Modul:    Modulübergreifend  
 * Funktionen:  Abstrahiert die Schnittstelle, welche ein Manager implementieren muss, damit ein generischer Finder davon bedient werden kann
 *********************************************************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjectInterfaces;

namespace PV.Interfaces
{
	/// <summary>
	/// Abstrahiert die Schnittstelle, welche ein Manager implementieren muss, 
	/// damit ein generischer Finder davon bedient werden kann
	/// </summary>
	public interface IFinderManager
	{
		#region Finder und Listen

		/// <summary>
		/// Liefert eine Liste initialer Finderobjekte
		/// </summary>
		/// <returns>Liste von Finderobjekten</returns>
		IList<IFinderObject> GetFirstList();

		/// <summary>
		/// Liefert die nächste Stufe von FinderObjekten für einen Parent
		/// </summary>
		/// <param name="parent">Der Parent</param>
		/// <returns>Liste von Finderobjekten</returns>
		IList<IFinderObject> GetNextList(IFinderObject parent, FinderSuchbaumSearchmode suchbaumSearchmethode);

		/// <summary>
		/// Liefert die vorige Stufe von FinderObjekten für einen Child
		/// </summary>
		/// <param name="child">Das Child</param>
		/// <returns>Liste von Finderobjekten</returns>
		IList<IFinderObject> GetPreviousList(IFinderObject child);

		/// <summary>
		/// Liefert die Liste von gleichrangigen Finderobjekten für ein gegebenes
		/// </summary>
		/// <param name="item">Das dedebene FinderObject</param>
		/// <returns>Liste von Finderobjekten</returns>
		IList<IFinderObject> GetListForItem(IFinderObject item);

		#endregion

		#region Breadcrumb

		/// <summary>
		/// Liefert die Liste der Breadcrumbeinträge
		/// </summary>
		/// <returns>IList von IFinderObjects</returns>
		IList<IFinderObject> BreadcrumbList
		{
			get;
		}

		/// <summary>
		/// Verarbeitet einen Klick in der Breadcrumb
		/// </summary>
		/// <param name="clickedItem">Das Item auf welches geklickt wurde</param>
		void SetBreadcrumbClick(IFinderObject clickedItem);

		/// <summary>
		/// Liefert die SearchBreadcrumb
		/// </summary>
		IList<IList<IFinderObject>> SearchBreadCrumb
		{
			get;
		}

		/// <summary>
		/// Filtert die VisibleTypenList anhand eines Klicks in die SuchBreadcrumb
		/// </summary>
		/// <param name="toFilter"></param>
		void FilterByBreadcrumbClick(IFinderObject toFilter);


		#endregion

		/// <summary>
		/// Liefert das zuletzt geklickte Item
		/// </summary>
		IFinderObject LastClickedItem
		{
			get;
		}

		/// <summary>
		/// Liefert die Überschriften einer Spalten im Finder
		/// Wenn es keine Überschriften gibt, wird ein leerer String zurück gegeben
		/// </summary>
		/// <returns>Die Spaltenüberschrift</returns>
		string GetColumnHeaders(int tiefe);

		FinderSuchbaumSearchmode SuchbaumSearchmode { get; set; }
	}

	public enum FinderSuchbaumSearchmode
	{
		NextList, // nächste 
		RecurseList // rekursive Suche erzwingen
	}
}
