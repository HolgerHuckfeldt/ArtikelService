/******************************************************************************************************
* Copyright Absolute Software GmbH 2008-2009
* Projekt:  PV-Kompass 
* Author:   Dirk Lannatewitz (ursprünglich IArtikelManager)
* Bearbeitet bzw Angepasst für Training: Tobias Schelle 
* Modul:    TrainingSuche
* Funktionen: Abstrahiert die Schnittstelle des Trainingmanagers und definiert seine Delegates 
*****************************************************************************************************/

using System.Collections.Generic;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.LMS;
using PV.Interfaces;

namespace PV.Business.Services
{
    /// <summary>
    /// Abstrahiert die Schnittstelle des Trainingmanagers
    /// </summary>
    public interface ITrainingBaseManager : IFinderManager, ISearchByStringManager
    {
        #region Properties

        List<TrainingsOrt> AlleTrainingsOrte
        {
            get;
        }

        List<string> TrainingsOrte
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt das selektierte Training
        /// </summary>
        Training SelectedTraining
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt die TrainingsTermine zum selektierte Training
        /// </summary>
        List<TrainingsTermin> SelectedTrainingsTermine
        {
            get;
        }

        /// <summary>
        /// Setzt und liefert eine gefilterte Trainingliste
        /// </summary>
        IList<Training> ViewableTrainingListe
        {
            get;
        }

        /// <summary>
        /// Liefert und setzt für ein T-Mod Bild die Ressource
        /// </summary>
        string RessourcePictureUri
        {
            get;
            set;
        }

        IList<SuchbaumEintrag> SuchbaumListe
        {
            get;
        }

        #endregion

        #region SetMethoden

        /// <summary>
        /// Methode zum Selektieren des Suchbaumeintrags durch die Oberfläche
        /// </summary>
        /// <param name="_eintrag">Der zu setzende Suchbaumeintrag als SuchbaumEintrag</param>
        void SelectSuchBaumEintrag(SuchbaumEintrag _eintrag);

        /// <summary>
        /// Methode zum Selektieren des Training durch die Oberfläche
        /// </summary>
        /// <param name="_artikel">Das zu setzende Training als Training</param>
        void SelectTraining(Training _training);

        /// <summary>
        /// Methode zum Selektieren des eines BreadcrumbEndpunktes durch die Oberfläche
        /// </summary>
        /// <remarks>Wird der BreadcrumbEndpunktes mit dieser Methode gesetzt, wird ViewableTraininglist gefiltert </remarks>
        /// <param name="_eintrag">Der zu setzende BreadcrumbEndpunktes</param>
        void SetCurrentTrainingSuchBreadcrumb(SuchbaumEintrag _eintrag);

        #endregion

        void LoadTermineZuSelectedTraining();

        void SetzeMetaDaten(Training training);
    }
}
