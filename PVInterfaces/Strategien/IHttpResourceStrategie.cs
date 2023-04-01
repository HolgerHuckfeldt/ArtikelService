using System;

namespace PVInterfaces.Strategien
{
    public interface IHttpResourceStrategie
    {
        /// <summary>
        /// Gibt den NAmen der Domain zurück, die von der STrategie behandelt wird,
        /// z.B. "katalog" für "pv.app://katalog/..." Uris
        /// </summary>
        /// <returns>Name der Domain</returns>
        string GetDomain();

        /// <summary>
        /// Erzeugt eine NetzUri (http://) für eine app interne Resourcen Uri in der zuständigen Domäne
        /// Es ist durchaus legitim, das eine Strategie hierfür zusätzliche Provider (Datenbank etc.) heranzieht,
        /// um diese zu erzeugen. Man sollte sich jedoch bewusst sein, das eine ResourceStrategie nicht im
        /// Kontext des Hauptthreads laufen muss und Semaphoren benutzen.
        /// </summary>
        /// <param name="pvUri"> Uri der Form: "pv.app://katalog/..."</param>
        /// <returns></returns>
        string GetNetUri(String pvUri);
    }
}
