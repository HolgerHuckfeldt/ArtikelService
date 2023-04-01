/***************************************************************************************************************************************
 * Copyright Absolute Software GmbH 2008-2009
 * Projekt:  PV-Kompass 
 * Author:   Susann Karras
 * Modul:    Technik
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für Technik erfüllen muss
 ***************************************************************************************************************************************/

using System.Collections.Generic;

using PV.DomainObjects.Artikel;
using PV.DomainObjects.Common;
using PV.DomainObjects.LMS;
using System;
using PV.DomainObjects.Mail.Smtp;

namespace PV.Persistance.Provider
{
    
    public interface ITrainingPersistanceProvider
    {
        #region Suchbaum-Funktionen

        
        List<SuchbaumEintrag> GetSuchbaumKategorieEintragList();

        
        List<SuchbaumEintrag> GetSuchbaumTrainingsOrteList();

        
        List<DomainObjects.LMS.Training> GetTrainingsByNodeId(int _nodeID);

        
        List<DomainObjects.LMS.Training> GetTrainingsByPlz(string _plz);

        
        List<DomainObjects.LMS.Training> GetTrainingsByOrt(string _ort);

        #endregion

        #region SearchByString

        
        List<DomainObjects.LMS.Training> GetTrainingsBySuchString(string _suchString);

        #endregion

        #region Get-Funktionen

        
        DomainObjects.LMS.Training GetTrainingById(string _artNr, int _dlNr, int _genArt);

        
        List<TrainingsOrt> GetAlleTrainingsOrte();

        
        List<string> GetTrainingsOrte();

        
        List<TrainingsTermin> GetTermineZuTraining(DomainObjects.LMS.Training _training);

        
        List<MeinTraining> GetEigeneTrainingsListe(int _mitarbeiterID);

        
        List<TrainingsAnmeldung> GetMeineAnmeldungen(int _mitarbeiterID);

        
        List<TrainingsAnmeldung> GetTrainingsAnmeldungen(string trArtNr, int trDLNr, int trGenArt, DateTime kkzAb, DateTime kkzBis);

        
        List<BedarfMeldung> GetMeineBedarfsmeldungen(int _mitarbeiterID);

        
        List<DomainObjects.Stammdaten.Mitarbeiter> GetLMSMitarbeiter(int _profilID);

        
        List<DomainObjects.Stammdaten.Mitarbeiter> GetTeilnehmerByEigenesTraining(int _id, int _profilID);

        
        List<DomainObjects.Stammdaten.Mitarbeiter> GetTeilnehmerByTermin(int _id, int _profilID);

        
        List<TrainingsAnmeldung> GetTrainingsAnmeldungenByTermin(int _id, int _profilID);

        
        List<DomainObjects.Stammdaten.Mitarbeiter> GetTeilnehmerByBedarfsmeldung(int _id, int _profilID);

        
        List<DomainObjects.Stammdaten.Mitarbeiter> GetTrainingsCardMitarbeiter(int profilID);

        
        int GetAnzahlDeletedTrainingsCardMitarbeiter(int profilID);
                
        
        int GetAnzahlAbsolvierterTrainingsTage(int profilID);

        
        List<PvImage> GetBilderByTraining(Training _training);

        
        string GetKategorie(DomainObjects.LMS.Training _training);

        #endregion

        #region Schreiben

        
        bool SchreibeBedarfmeldung(BedarfMeldung _meldung, int _profilID);

        
        bool SchreibeAnmeldung(TrainingsAnmeldung _anmeldung, int _profilID);

        
        bool SaveTrainingsCardMitarbeiter(IList<DomainObjects.Stammdaten.Mitarbeiter> tcMitarbeiter, PV.DomainObjects.Stammdaten.Profil _profil);

        
        bool SchreibeMeinTraining(MeinTraining _training, int _profilID);

        #endregion

        #region Updaten

        
        bool AktualisiereMeinTraining(MeinTraining _training, int _profilID);

        
        bool AktualisiereBedarfsMeldung(BedarfMeldung _meldung, int _profilID);

        #endregion

        #region Löschen

        
        bool LoescheTeilnahmeAnEigenesTraining(MeinTraining _training, int _mitarbeiterLmsID);

        
        bool LoescheTeilnahmeAnBedarfsMeldung(BedarfMeldung _meldung, int _mitarbeiterLmsID);

        #endregion

        #region SendAnmeldeBestaetigung
        
        SmtpMessage SendAnmeldeBestaetigung(TrainingsAnmeldung _anmeldung, PV.DomainObjects.Stammdaten.MitarbeiterWebservice _mitarbeiter, String copyEmpfaenger,
            String lms_email_from);

        # region SendBedarfsmeldungsBestaetigung
        
        SmtpMessage SendBedarfsmeldungsBestaetigung(BedarfMeldung _bedarfsmeldung, PV.DomainObjects.Stammdaten.MitarbeiterWebservice _mitarbeiter, String copyEmpfaenger, String lms_email_from);
        #endregion

        #endregion
    }
}
