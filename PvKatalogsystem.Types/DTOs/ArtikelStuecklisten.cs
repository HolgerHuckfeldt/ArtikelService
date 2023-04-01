using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PvKatalogsystem.Types.DTOs
{
    [Serializable]
    [DataContract]
    public class ArtikelStuecklisten:DtoBase
    {
        public ArtikelStuecklisten()
        {
            TecdocStueckliste = new List<Stuecklistenartikel>();
            PvStueckliste = new List<Stuecklistenartikel>();
        }

        [DataMember]
        public List<Stuecklistenartikel> TecdocStueckliste { get; set; }
        [DataMember]
        public List<Stuecklistenartikel> PvStueckliste { get; set; }

        public override string ToString()
        {
            return string.Format("PV: {0}, TECDOC: {1}", PvStueckliste.Count, TecdocStueckliste.Count);
        }
    }
}
