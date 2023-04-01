using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Warenkorb.Transactions
{
    [Serializable]
    public class wkAlternativenTransactionReq
    {
        public Artikel.VdbArtikelId Id{ get; set; }
        public Decimal Menge;

        public string Systembenutzer { get; set; }
        public string Systempasswort { get; set; }
        public VdbUserInfo VdbUserInfo { get; set; }
    }
}
