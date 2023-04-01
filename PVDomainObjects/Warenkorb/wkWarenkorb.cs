using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Bestellung;
using PV.DomainObjects.Statistic;
using PV.DomainObjects.Warenkorb.Kalender;

namespace PV.DomainObjects.Warenkorb
{
    [DataContract]
    [Serializable]
    public class wkWarenkorb : IWarenkorb
    {
        private static long _instanceCount;

        public wkWarenkorb()
        {
            Bonuspunkte = new List<Bonus>();
            Interlocked.Add(ref _instanceCount, 1);
        }

        /// <summary>
        /// If set to true, the WarenkorbChanged event is suppressed.
        /// This property is used by the VDB update in order to silently 
        /// replace the whole Warenkorb object
        /// </summary>
        public bool SupressChangedEvent { get; set; }

        [DataMember]
        private readonly List<wkPosition> _Positionen = new List<wkPosition>();

        [DataMember]
        private Boolean _IstWarenkorbReserviert;

        [DataMember]
        private wkDay _Liefertermin;
        
        [DataMember]
        private DateTime _LieferterminDateTime;

        [DataMember]
        public String StatusFailedText { get; set; }

        [DataMember]
        public string CreationUser
        {
            get;
            set;
        }

        [DataMember]
        public string CreationProfil
        {
            get;
            set;
        }

        [DataMember]
        public DateTime CreationTime
        {
            get;
            set;
        }

        [DataMember]
        public long Lieferbonus
        {
            get;
            set;
        }

        [DataMember]
        public long LieferbonusInfo
        {
            get;
            set;
        }

        [DataMember]
        public bool PerformBestellungAufruf
        {
            get;
            set;
        }

        [DataMember]
        public long BestellId
        {
            get;
            set;
        }

        [DataMember]
        public string OfflineBestellId
        {
            get;
            set;
        }

        public bool VDBVerfuegbar
        {
            get;
            set;
        }

        [DataMember]
        public long ResponseID_ValidateWarenkorb
        {
            get;
            set;
        }

        [DataMember]
        public Decimal EkSumme
        {
            get;
            set;
        }

        [DataMember]
        private readonly Guid _warenkorbId = Guid.NewGuid();

        [DataMember]
        public long? BelegNummer
        {
            get;
            set;
        }

        [DataMember]
        public string Titel
        {
            get;
            set;
        }


        public Guid WarenkorbId
        {
            get
            {
                return _warenkorbId;
            }
        }

        public Boolean IstWarenkorbReserviert
        {
            get
            {
                return _IstWarenkorbReserviert;
            }
            set
            {
                if (_IstWarenkorbReserviert != value)
                {
                    _IstWarenkorbReserviert = value;
                    OnWarenkorbChanged();
                }
            }
        }

        public wkDay Liefertermin
        {
            get
            {
                return _Liefertermin;
            }
            set
            {
                _Liefertermin = value;
                //EventBroker.Instance.RaiseTopic(EventTopics.WarenkorbAktuellLieferterminChanged, this, new EventArgs());
            }
        }

        public DateTime LieferterminDateTime
        {
            get
            {
                return _LieferterminDateTime;
            }
            set
            {
                _LieferterminDateTime = value;
            }
        }



        public IWarenkorbPosition Add(Artikel.Artikel artikel, decimal count)
        {
            // nur zum testen

            //if (artikel.TecComDeleveryArtikel != null)
            //    Add(artikel.TecComDeleveryArtikel, 1);

            return Add(artikel, count, null);
        }

        public IWarenkorbPosition Add(Artikel.Artikel artikel, decimal count, Artikel.Artikel deliveryArtikel)
        {
            
            Guid? guid = OnAddingArtikel(artikel, count, null);
            if (!guid.HasValue)
            {
                return Add(artikel, count, Guid.Empty, true, deliveryArtikel);
            }
            return Add(artikel, count, guid.Value, true, deliveryArtikel);
        }

        public IWarenkorbPosition Add(Artikel.Artikel artikel, decimal count, Guid repDocGuid, bool throwOnWarenkorbChangedEvent)
        {
            return Add(artikel, count, repDocGuid, throwOnWarenkorbChangedEvent, null);
        }

        public IWarenkorbPosition Add(Artikel.Artikel artikel, decimal count, Guid repDocGuid, bool throwOnWarenkorbChangedEvent, Artikel.Artikel deliveryArtikel)
        {

            try
            {
                if (artikel != null)
                {
                    var entry = new StatisticEntry();
                    entry.ExtraInfo = "Add: " + artikel.ArtikelNummer + "," + artikel.HLK + "," + count;
                    entry.Location = "Kompass.WK";

                    if (artikel.ExtraInfos != null && artikel.ExtraInfos.ContainsKey("Type"))
                    {
                        if (artikel.ExtraInfos["Type"] == "Inspektionsöl")
                            return null;
                    }


                    if (artikel.ExtraInfos != null && artikel.ExtraInfos.ContainsKey("Herkunft"))
                    {
                        var herkunft = artikel.ExtraInfos["Herkunft"];
                        var oe = "";
                        if (artikel.ExtraInfos.TryGetValue("OE", out oe))
                        {
                            var newentry = new StatisticEntry();
                            newentry.ExtraInfo = "ArtikelMatched: " + artikel.ArtikelNummer + ", Herkunft: " + herkunft + ", OE: " + oe;
                            newentry.Location = "Kompass.WK";
                            //EventBroker.Instance.RaiseTopic(EventTopics.StatisticManagerAddEntry, this, new StatisticEventArgs()
                            //{
                            //    Entry = newentry
                            //});
                        }
                    }

                }
            }
            catch (Exception)
            {
                
            }

            IWarenkorbPosition existing =
                (from x in Positionen
                 where x.ArtikelRef.ArtikelNummer == artikel.ArtikelNummer
                    && x.ArtikelRef.HLK == artikel.HLK
                 //&& x.RepdocGuid == Guid.Empty
                 select x).FirstOrDefault();

            if (existing != null && repDocGuid == Guid.Empty)
            {

                if (existing.IsTecCom != artikel.IsTecComArtikel)
                {
                    //EventBroker.Instance.RaiseTopic(EventTopics.WarenkorbArtikelTecComNotAdded, null);
                    return existing;
                }

                //if ( existing.IsTecCom && !artikel.IsTecComArtikel)
                //{
                //    // Message, man darf den nicht hinzufügen.
                //    EventBroker.Instance.RaiseTopic(EventTopics.WarenkorbArtikelTecComNotAdded, null);
                //    return existing;
                //}

                if(existing.TecComTransportArtikelRef == null) existing.TecComTransportArtikelRef = deliveryArtikel;

                if (existing.IsTecCom)
                    existing.Menge = count;
                else
                    existing.Menge += count;

                OnArtikelAdded(artikel, existing, true, count);
                IstWarenkorbReserviert = false;
                OnWarenkorbChanged();
                return existing;
            }

            // check whether the Artikel already existed in the collection 
            var data =
                (from x in Positionen
                 where x.ArtikelRef.EqualsArtikel(artikel)
                 select x).Count();

            wkPosition pos = new wkPosition(this, artikel, count);
            pos.TecComTransportArtikelRef = deliveryArtikel;
            pos.RepdocGuid = repDocGuid;
            Positionen.Add(pos);

            // the Artikel was not present before, so we gotta trigger 
            // an event, so that the TopbonusManager can hook in
            OnArtikelAdded(artikel, pos, data > 0, count);
            if (throwOnWarenkorbChangedEvent)
            {
                OnWarenkorbChanged();
            }
            return pos;
        }


        public void Remove(Artikel.Artikel artikel)
        {
            //bool change = false;

            try
            {
                if (artikel != null)
                {
                    var entry = new StatisticEntry();
                    entry.ExtraInfo = "Remove: " + artikel.ArtikelNummer + "," + artikel.HLK;
                    entry.Location = "Kompass.WK";

                }
            }
            catch (Exception)
            {

            }

            for (int x = Positionen.Count - 1; x >= 0; x--)
            {
                if (Positionen[x].ArtikelRef.EqualsArtikel(artikel))
                {
                    Positionen.RemoveAt(x);
                    //change = true;
                }
            }

            //von Thomas (10.05.2010): dies muss auskommentiert bleiben, da sonst über OnReservationTick der Warenkorb storniert wird
            //neue Lösung: nach Entfernung eines Artikels, wird validateWarenkorb sofort aufgerufen, somit braucht IstWarenkorbReserviert nicht auf false gesetzt werden
            //if (change)
            //{
            //    IstWarenkorbReserviert = false;
            //}

            OnWarenkorbChanged();
        }

        public IList<wkPosition> Positionen
        {
            get
            {
                return _Positionen;
            }
        }

        public void SetPositions(IList<wkPosition> _positions)
        {
            _Positionen.Clear();
            foreach (wkPosition position in _positions)
            {
                _Positionen.Add(position);
            }


            //var tecComDeliverys =
            //    (from s in _positions where s.ArtikelRef != null && s.ArtikelRef.TecComDeleveryArtikel != null orderby s.ArtikelRef.DatenlieferantenNummer select s)
            //        .ToList();

            //foreach (var tecComDelivery in tecComDeliverys)
            //{
            //    // gibt es für diese dlnr schon eine delivery-Pos?

            //    var t = (from s in _positions
            //        where
            //            s.ArtikelRef != null && s.ArtikelRef.IsTecComDeleveryArtikel &&
            //            s.ArtikelRef.TecComDeleveryDlnr == tecComDelivery.ArtikelRef.DatenlieferantenNummer
            //        select s).ToList();

            //    if (!t.Any())
            //        Add(tecComDelivery.ArtikelRef.TecComDeleveryArtikel, 1);

            //}

            if (PerformBestellungAufruf)
                IstWarenkorbReserviert = true;
            OnWarenkorbChanged();
        }

        [DataMember]
        public List<Bonus> Bonuspunkte
        {
            get;
            set;
        }

        [DataMember]
        public string BestellnotizAngabe
        {
            get;
            set;
        }

        [DataMember]
        public string BestellnotizBestellnummer
        {
            get;
            set;
        }

        private void OnArtikelAdded(Artikel.Artikel _artikel, object id, bool alreadyExisted, decimal menge)
        {
            if (!_artikel.KeineNotwendigenArtikelLaden)
            {
                var args = new ArtikelAddedEventArgs(_artikel, id, alreadyExisted, menge);
                //EventBroker.Instance.RaiseTopic(EventTopics.WarenkorbAktuellArtikelAdded, this, args);
            }
        }

        private Guid? OnAddingArtikel(Artikel.Artikel artikel, Decimal menge, Guid? guid)
        {
            AddingPositionEventArgs e = new AddingPositionEventArgs(artikel, menge, guid);
            //EventBroker.Instance.RaiseTopic(EventTopics.WarenkorbAktuellAddingPosition, this, e,false,EventExecutionMode.Send);
            return e.PosGuid;
        }
     
        public void OnWarenkorbChanged()
        {
            // check if an internal update is in progress
            // we might need to supress the event trigger
            if (SupressChangedEvent)
            {
                return;
            }

            //EventBroker.Instance.RaiseTopic(EventTopics.WarenkorbAktuellChanged, this, new EventArgs());
        }

        [DataMember]
        private Liefermodi _lieferart;

        public Liefermodi Lieferart
        {
            get
            {
                return _lieferart;
            }
            set
            {
                _lieferart = value;
            }
        }
    }
}