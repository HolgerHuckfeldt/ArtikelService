using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.DomainObjects.Common
{
    [Serializable]
    public enum SuchFilterTypen
    {
        None,
        Artikelnummern,
        Gebrauchsnummern,
        Referenznummern,
        EANummen
    }
}
