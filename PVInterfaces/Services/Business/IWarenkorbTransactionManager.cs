using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Artikel;
using PV.DomainObjects.Bestellung;
using PV.DomainObjects.Warenkorb;

namespace PV.Business.Services
{
    public delegate void UpdateWarenkorbAsyncCompleted( IWarenkorbTransactionManager sender, IWarenkorb _warenkorb );

    public interface IWarenkorbTransactionManager
    {
        void ResetState();
        
        byte[] SaveCurrentWarenkorbState(IWarenkorb warenkorb);

        void LoadCurrentWarenkorbState( byte[] data, IWarenkorb warenkorb );

        void UpdateWarenkorbAsync( IWarenkorb _warenkorb, UpdateWarenkorbAsyncCompleted _callback );

        List<wkAlternativArtikel> LoadAlternativArtikel( Artikel _artikel, Decimal _menge );

        bsBestellung PerformBestellung( IWarenkorb _warenkorb );

        void StorniereWarenkorb( IWarenkorb _warenkorb, VdbUserInfo _userinfo );

        bsBestellung SaveFromValidateWarenkorb( IWarenkorb _warenkorb );

        /// <summary>
        /// Gibt an ob ein serialisierbarer Response von der VDB vorhanden ist
        /// </summary>
        bool CanSerialize
        {
            get;
        }
    }
}
