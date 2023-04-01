using System;
using System.Security.Cryptography.X509Certificates;
using PV.DomainObjects.Artikel;

namespace PV.Business.Services
{
    public interface IDurchlaufartikelManager : INummernArtikelManager
    {
        void AddDurchlaufartikel(String artikelnummer, Decimal menge, Guid guid);
        //void AddDurchlaufartikel(String artikelnummer, Decimal menge, object tag, Guid guid);
        void AddDurchlaufartikel(String artikelnummer, string Hersteller, double ekPreis, double vkPreis, string Bezeichnung, Decimal menge, bool eaArtikel, Guid guid);
        bool OEMode { get; set; }
        bool ArtikelEindeutigMode { get; set; }
        string Herkunft { get; set; }
        Boolean ProcessNextDurchlaufartikel();
        DurchlaufArtikel CurrentDurchlaufArtikel { get; set; }
        Boolean DurchlaufartikelOnStack { get; }
        void Init();
        void Deinit(); 
    }
}
