/*********************************************************************************************************
 * Copyright    Absolute Software GmbH 2008-2009
 * Projekt:     PV-Kompass 
 * Author:      Walter Licht
 * Modul:       Artikelsuche 
 * Funktionen:  Abstrahiert die Schnittstelle welche ein Provider für die VDB-Datenbank erfüllen muss
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Warenkorb;
using PV.DomainObjects.Warenkorb.Transactions;

using PV.DomainObjects.Plus.PlusWarenkorb;
using PV.DomainObjects.Bestellung;

namespace PV.Persistance.Provider
{
    /// <summary>
    /// Kontakt von einem Artikel zur Vertriebsdatenbank.
    /// Informationen zu Preisen, verfügbarkeit und 
    /// Lieferterminen zu den Artikeln.
    /// Außerdem bestellen und "reservieren" von Artikeln.
    /// </summary>
    
    public interface IVDBProvider
    {
        //List<PreisStaffel> GetArtikelDatails(Artikel _artikel);

        //IList<VdbArtikelInfo> GetVdbArtikelInfos(IList<VdbArtikelId> _artikelListe);
        //Warenkorb UdpWarenkorb(Warenkorb _warenkorb);
        //void GetStaffelPreise(Artikel _artikel);
        //int GetRueckstaende();
        //IList<Rueckstand> GetRueckstandsdetails();
        //bool RueckstandLoeschen(Rueckstand _rueckstand);

        //-- 3 Funktionen für Staffelpreise: GetArtikelDatails wird z.Zt. benutzt 
        
        List<PreisStaffel> GetArtikelDatails( VdbUserInfo userInfo, Artikel _artikel );
        //-----------------------

        
        IList<VdbArtikelInfo> THGetVdbArtikelInfos(IList<VdbArtikelId> _artikelListe, wkTransactionBaseReq baseReq);  // Thomas Debugversion
        
        //-----------------------
        
        wkWarenkorbTransactionResp UdpWarenkorbAsync(wkWarenkorbTransactionReq _warenkorb, IWarenkorb _currentWarenkorb);
        
        
        Bestellresponse THDoBestellung(BestellRequest _bestellRequest, PV.DomainObjects.Plus.Lieferadresse _Lieferadresse);

        bool SendHandelspartnerHybridBestellung(bsBestellung bestellung, int profilId);
        //-----------------------
        
        int GetRueckstaende(VdbUserInfo userInfo);
        
        IList<Rueckstand> GetRueckstandsdetails(VdbUserInfo userInfo);
        
        bool RueckstandLoeschen(VdbUserInfo userInfo, Rueckstand _rueckstand);

        /// <summary>
        /// Warenkorb Stronieren (sofern BestellId schon vergeben wurde)
        /// </summary>
        /// <param name="_bestellRequest"></param>
        
        void WarenkorbStornieren(StornoRequest _bestellRequest, IWarenkorb _currentWarenkorb);

        //--- PV:PLUS
        //KontoInfos THVdbGetKontoinformationen();

        
        List<wkArtikelAlternativenTransactionResp> THGetAlternativen(
            wkAlternativenTransactionReq AlternativenTransaction);

        
        int THExternP(DomainObjects.Plus.plusExternePunkteRequest _ExternePunkteRequest);

        
        Liefertour THGetLiefertour(VdbUserInfo userInfo);

        
        List<ArtikelVdbAddition> GetAdditionalArtikelInfos(VdbUserInfo userInfo, IList<VdbArtikelId> _artikelListe);

        
        PV.DomainObjects.VDBGetLoginResponse GetLogin(VdbUserInfo userInfo);

        
        PV.DomainObjects.VDBGetNeinTageListe THGetNeinTage(VdbUserInfo userInfo, DateTime _DatumSpecified);

        
        KontoInfos THVdbGetKontoinformationen(VdbUserInfo userInfo);
        
        
        News ThVdbGetNews(VdbUserInfo userInfo);
                
        //PVSoapOnlineVdbProvider.WeltWarenkorb.LiefertourResponse THGetLiefertour();

        //List<PVSoapOnlineVdbProvider.WeltWarenkorb.VerfuegbarkeitResponse> THGetVdbVerfuegbarkeit( Warenkorb _warenkorb );

        //PVSoapOnlineVdbProvider.PVWeltUtility.NeintageResponse THGetNeinTage();
        //PVSoapOnlineVdbProvider.PVWeltUtility.LoginResult THGetLogin();
        //PVSoapOnlineVdbProvider.PVWeltUtility.FehlercodeListeResponse THGetFehlercode();
        //PVSoapOnlineVdbProvider.WeltWarenkorb.LiefertourResponse THGetLiefertour();
        //PVSoapOnlineVdbProvider.WeltArtikelVdb.ArtikelAlternativeListeResponse THGetAlternativen();

    }
}
