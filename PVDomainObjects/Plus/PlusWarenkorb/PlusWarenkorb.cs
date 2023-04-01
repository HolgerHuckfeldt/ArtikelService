using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PV.DomainObjects.Warenkorb;
using PV.DomainObjects.Warenkorb.Transactions;
//using PV.Utilities.SystemConfiguration;

namespace PV.DomainObjects.Plus.PlusWarenkorb
{
    public class PlusWarenkorb
    {
        private readonly List<PlusWarenkorbPosition> _positionen;
        private readonly List<PlusWarenkorbPositionVdb>  _positionenVdb;

        public static bool DummyVDBProvider
        {
            get
            {
                return false;
                //return Convert.ToBoolean(ConfigManager.Instance.GetSetting("dummyvdb_provider"));
            }
        }

        public PlusWarenkorb()
        {
            PlusPunkteSumme = 0;
            _positionen = new List<PlusWarenkorbPosition>();
            _positionenVdb = new List<PlusWarenkorbPositionVdb>();
        }

        public IList<PlusWarenkorbPosition> Positionen
        {
            get
            {
                return _positionen.AsReadOnly();
            }
        }

        public void AddPraemienArtikel(PraemienArtikel artikel, Decimal menge)
        {
            var eqPosition =
                (from p in _positionen
                 where p.Artikel.ArtikelNummer == artikel.ArtikelNummer && p.Artikel.DatenlieferantenNummer == artikel.DatenlieferantenNummer
                 select p).FirstOrDefault();

            if (eqPosition == null)
                _positionen.Add(new PlusWarenkorbPosition(artikel, menge, artikel.AnzahlPunkte, Convert.ToInt32(artikel.AnzahlPunkte * menge),
                    wkPositionStatus.Neu, 0, this));
            else
            {
                eqPosition.Menge += menge;
                eqPosition.PlusPunkteSumme = Convert.ToInt32(artikel.AnzahlPunkte * eqPosition.Menge);
            }

            OnChanged();
        }

        public void RemovePosition(PlusWarenkorbPosition position)
        {
            if (_positionen.Contains(position))
                _positionen.Remove(position);

            OnChanged();
        }

        public Boolean IstBestellbar
        {
            get
            {
                if((_positionenVdb.Count == _positionen.Count)
                    && (_positionen.Count > 0))
                {
                    for(int i = 0; i<_positionen.Count; ++i)
                    {
                        if(_positionen[i].VdbStatus != wkPositionStatus.Reserviert || !(_positionenVdb[i].Menge == _positionen[i].Menge && _positionenVdb[i].PositionsNummer == _positionen[i].PositionsNummer))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
        }

        public Boolean StatusFailed { get; private set; }

        public String StatusFailedText { get; set; }

        public long BestellId { get; private set; }

        public string OfflineBestellId { get; private set; }

        public Int32 PlusPunkteSumme
        {
            get; private set;
        }

        /// <summary>
        /// Liefert die geschätzte Summe des Warenkorbs ohne Vdb Validierung (kumuliert)
        /// </summary>
        public Int32 PlusPunkteSummeKumuliert
        {
            get
            {
                return (Int32) Positionen.Sum(x => x.Artikel.AnzahlPunkte*x.Menge);
            }
        }


        public void OnChanged()
        {
            if(Changed != null)
            {
                Changed(this, new EventArgs());
            }
        }

        public event EventHandler Changed;

        public void Clear()
        {
            BestellId = 0;
            OfflineBestellId = string.Empty;
            _positionen.Clear();
            _positionenVdb.Clear();
            OnChanged();
        }

        public long ResponseID_ValidateWarenkorb
        {
            get;
            set;
        }

        #region VdbInteraktionslogik
        public void BuildWarenkorbFromResponse(wkWarenkorbTransactionResp response)
        {
            int count = response.PositionTransactions == null ? 0 : response.PositionTransactions.Count();
            List<PraemienArtikel> praemienArtikel = _positionen.Select(x => x.Artikel).ToList();

            _positionen.Clear();
            _positionenVdb.Clear();
            
            if (count == 0)
            {
                OnChanged();
                return;
            }

            foreach (wkPositionTransactionResp positionTransaction in response.PositionTransactions)
            {
                // try to find item in our cache
                PraemienArtikel art = (from a in praemienArtikel
                               where
                                   a.VDBArtikelNummer == positionTransaction.Artikelnummer &&
                                   a.HLK == positionTransaction.HLK
                               select a).FirstOrDefault();

                // not found, we need to load the data
                if (art == null)
                {
                    art = new PraemienArtikel();
                    art.VDBArtikelNummer = positionTransaction.Artikelnummer;
                    art.HLK = positionTransaction.HLK;
                }

                var pos = new PlusWarenkorbPosition(art, positionTransaction.UnterPositionTransactions.Sum(x => x.Menge),
                                                    (Int32)art.AnzahlPunkte,
                                                    (Int32)(art.AnzahlPunkte * positionTransaction.UnterPositionTransactions.Sum(x => x.Menge)),
                                                    positionTransaction.VDBStatus, positionTransaction.Nr, this);

                _positionen.Add(pos);
                _positionenVdb.Add(new PlusWarenkorbPositionVdb(pos.Menge,pos.PositionsNummer,pos.Artikel.VDBArtikelNummer,pos.Artikel.HLK, pos.PlusPunkte));
            }

            PlusPunkteSumme = (Int32)response.Bonuspunkte.Sum(x => x.Punkte);
            BestellId = response.BestellId;
            OfflineBestellId = response.OfflineBestellId;

            ResponseID_ValidateWarenkorb = response.ResponseId;
            StatusFailed = response.ErrorCode != 0 || response.ErrorCodeUser != 0;
            StatusFailedText = response.Message;

            OnChanged();
        }

        /// <summary>
        /// Gibt alle Elemente zurück, die seit dem letzten Warenkorb Update hinzugefügt wurden
        /// </summary>
        /// <param name="warenkorb"></param>
        /// <returns></returns>
        private IEnumerable<wkPositionTransactionReq> BuildTransactionListAdd()
        {
            List<wkPositionTransactionReq> list = new List<wkPositionTransactionReq>();

            foreach (var position in _positionen)
            {
                if (position.PositionsNummer == 0)
                {
                    wkPositionTransactionReq request = BuildBasicRequest(position);

                    // disallow an amount of 0
                    request.Menge = position.Menge == 0 ? 1 : position.Menge;
                    request.Statusflag.Add(enPositionStatusflag.neuerArtikel);
                    list.Add(request);
                }
            }
            return list;
        }

        /// <summary>
        /// Gibt alle Element zurück, die seit dem letzten Warenkorb Update gelöscht wurden
        /// </summary>
        /// <param name="warenkorb"></param>
        /// <returns></returns>
        private IEnumerable<wkPositionTransactionReq> BuildTransactionListDel()
        {
            List<wkPositionTransactionReq> list = new List<wkPositionTransactionReq>();

            var geloeschtePositionen =
                (from p in _positionenVdb
                 where !_positionen.Where(x => x.PositionsNummer == p.PositionsNummer).Any()
                 select p).ToList();

            foreach (var position in geloeschtePositionen)
            {
                wkPositionTransactionReq request = BuildBasicRequest(position);
                request.Statusflag.Add(enPositionStatusflag.Artikelgelöscht);
                request.Nr = position.PositionsNummer;
                list.Add(request);
            }
            return list;
        }

        
        /// <summary>
        /// Gibt alle Element zurück, dessen Menge seit dem letzten Warenkorb Update verändert wurde
        /// </summary>
        /// <param name="warenkorb"></param>
        /// <returns></returns>
        private IEnumerable<wkPositionTransactionReq> BuildTransactionListChange()
        {
            List<wkPositionTransactionReq> list = new List<wkPositionTransactionReq>();

            foreach (var position in _positionenVdb)
            {
                var changedPosition =
                    _positionen.Where(x => x.PositionsNummer == position.PositionsNummer).SingleOrDefault();
                if (changedPosition != null)
                {
                    
                    bool needsUpdate = false;
                    wkPositionTransactionReq request = BuildBasicRequest(position);
                    request.Nr = position.PositionsNummer;

                    if (DummyVDBProvider)
                    {
                        request.Statusflag.Add(enPositionStatusflag.ÄnderungDerMenge);

                        // disallow an amount of 0
                        request.Menge = changedPosition.Menge == 0 ? 1 : changedPosition.Menge;

                        needsUpdate = true;
                    }
                    else
                    {
                        //did the "amount" change?
                        if (changedPosition.Menge != position.Menge)
                        {
                            request.Statusflag.Add(enPositionStatusflag.ÄnderungDerMenge);

                            // disallow an amount of 0
                            request.Menge = changedPosition.Menge == 0 ? 1 : changedPosition.Menge;

                            needsUpdate = true;
                        }
                    }

                    if (needsUpdate)
                    {
                        list.Add(request);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// Erstellt ein wkPositionTransactionReq Objekt und initialisiert die Felder mit Default Werten
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private wkPositionTransactionReq BuildBasicRequest(PlusWarenkorbPosition position)
        {
            wkPositionTransactionReq request = new wkPositionTransactionReq();
            request.Artikelnummer = position.Artikel.VDBArtikelNummer;
            request.HLK = position.Artikel.HLK;
            request.Menge = position.Menge;
            request.Nr = 0;
            request.BatterieStatus = enBatteriestatus.nichtgefüllteBatterie;
            request.PosGuid = Guid.NewGuid();
            request.PreisBonuspunkte = position.PlusPunkte;
            return request;
        }

        /// <summary>
        /// Erstellt ein wkPositionTransactionReq Objekt und initialisiert die Felder mit Default Werten
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private wkPositionTransactionReq BuildBasicRequest(PlusWarenkorbPositionVdb position)
        {
            wkPositionTransactionReq request = new wkPositionTransactionReq();
            request.Artikelnummer = position.VdbArtikelnummer;
            request.HLK = position.Hlk;
            request.Menge = position.Menge;
            request.Nr = 0;
            request.BatterieStatus = enBatteriestatus.nichtgefüllteBatterie;
            request.PosGuid = Guid.NewGuid();
            request.PreisBonuspunkte = position.PreisBonuspunkte;
            return request;
        }
        #endregion
        public IList<wkPositionTransactionReq> BuildTransactionFromWarenkorb()
        {
            var transList = new List<wkPositionTransactionReq>();

            transList.AddRange(BuildTransactionListChange());
            transList.AddRange(BuildTransactionListAdd());
            transList.AddRange(BuildTransactionListDel());

            return transList;
        }

    }
}
