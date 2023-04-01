using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PV.DomainObjects.Bestellung;
using PV.DomainObjects.CMS;

namespace PV.Business.Services
{
    public interface IBestellbestaetigungsManager
    {
        string LastFileName { get; set; }
        Boolean NeueBestaetigung(bsBestellung _bestellung);
        Boolean NeueBestaetigung(bsBestellung bestellung, CmsHpObject logo, bool setLastFile);

        string NeueBestaetigungAusOnlineDB(bsBestellung bestellung);

        Boolean NeueBestaetigungWarenkorbPlus(bsBestellung _bestellung);
        void ShowLastBestaetigung();
    }
}
