using System;
using System.Threading;
using System.Runtime.Serialization;
using PV.DomainObjects.Common;
using PV.Utilities.Interfaces;


namespace PV.Business.Services
{

    [DataContract]
    public enum RessourceResult
    {
        [EnumMember]
        File,
        [EnumMember]
        RAW
    }

    /// <summary>
    /// Beschreibt die Schnittstelle, welche ein Manager zur Ressourcenanforderung erfüllen muss
    /// </summary>
    public interface IRessourceManager
    {
        /// <summary>
        /// Lädt eine Explosion
        /// </summary>
        /// <param name="exp"></param>
        void LoadExplosion(TemotExplosion exp);

        /// <summary>
        /// Lädt eine durch das PVBildDO definierte Resource in dieses, bzw. stellt sie zur Anzeige bereit
        /// </summary>
        /// <param name="_image"></param>
        void LoadImage(PvImage _image, bool thumb);

        /// <summary>
        /// Forder eine Bildressource synchron an
        /// </summary>
        /// <param name="suri">Der Uri des Bildes</param>
        /// <param name="thumb">True, wenn ein Thumbnail geliefert werden soll</param>
        /// <param name="ResResult">Gibt an, ob der geforderte URI als Datei oder byte[] geliefert werden soll</param>
        /// <returns></returns>
        object GetRessourceSync(string suri, bool thumb, RessourceResult ResResult);

        /// <summary>
        /// Fordert eine Bildressource an
        /// </summary>
        /// <param name="uri">Der Uri des Bildes</param>
        /// <param name="thumb">True, wenn ein Thumbnail geliefert werden soll</param>
        /// <param name="callBack">Die Callbackfunktion, welche ausgeführt wird, wenn das Bild geladen ist</param>
        /// <returns></returns>
        Guid GetRessource(Uri uri, bool thumb, RessourceResult ResResult, SendOrPostCallback callBack);

        /// <summary>
        /// Fordert eine Bildressource an
        /// </summary>
        /// <param name="bildname">Der Bildname</param>
        /// <param name="thumb">True, wenn ein Thumbnail geliefert werden soll</param>
        /// <param name="callBack">Die Callbackfunktion, welche ausgeführt wird, wenn das Bild geladen ist</param>
        /// <returns></returns>
        Guid GetRessource(string bildname, bool thumb, RessourceResult ResResult, SendOrPostCallback callBack);

        /// <summary>
        /// Fordert eine Bildressource an
        /// </summary>
        /// <param name="dateiname">Der Dateiname des Bildes</param>
        /// <param name="dl">Der Datenlieferant</param>
        /// <param name="thumb">True, wenn ein Thumbnail geliefert werden soll</param>
        /// <param name="callBack">Die Callbackfunktion, welche ausgeführt wird, wenn das Bild geladen ist</param>
        /// <returns></returns>
        Guid GetRessource(string dateiname, int dl, string type, bool thumb, RessourceResult ResResult, SendOrPostCallback callBack);

        /// <summary>
        /// Übersetzt eine System Uri in eine WebUri
        /// </summary>
        /// <param name="pvImageUri"></param>
        /// <param name="thumb"></param>
        /// <returns></returns>
        String GetWebUri(Uri pvImageUri, Boolean thumb);

        /// <summary>
        /// Übersetzt eine System Uri in eine WebUri
        /// </summary>
        /// <param name="pvImageUri"></param>
        /// <returns></returns>
        String GetWebUri(Uri pvImageUri);
    }
}
