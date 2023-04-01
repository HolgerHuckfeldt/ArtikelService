using System;
using PV.Utilities.Misc;
using PV.DomainObjects.Artikel;

namespace PV.DomainObjects.ManagedObjects
{
    [Serializable]
    public class IncentiveArtikelListe : PVItemListe<Artikel.Artikel>
    {
        public OelEmpfehlung OelEmpfehlungen { get; set; }
    }
}
