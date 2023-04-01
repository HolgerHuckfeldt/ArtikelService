using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PVInterfaces.Services.Persistance
{
 
    public interface IPlusLoginProvider
    {
        /// <summary>
        /// Legt einen neuen Anmeldedatensatz in der Tabelle "PVPlusAnmeldungen" an.
        /// </summary>
        /// <param name="profilID"></param>
        /// <param name="anmelder"></param>
        /// <param name="anmeldeDatum"></param>
        /// <param name="abwPraemienadresse"></param>
        /// <param name="empfaengerAbw"></param>
        /// <param name="empfaengerZusatzAbw"></param>
        /// <param name="strasseAbw"></param>
        /// <param name="adressZusatzAbw"></param>
        /// <param name="plzAbw"></param>
        /// <param name="ortAbw"></param>
        
        bool PlusAnmelden(int profilID, string anmelder, DateTime anmeldeDatum, bool abwPraemienadresse,
                          string empfaengerAbw, string empfaengerZusatzAbw, string strasseAbw, string adressZusatzAbw, string plzAbw,
                          string ortAbw);

        /// <summary>
        /// Aktualisiert den Anmeldedatensatz in der Tabelle "PVPlusAnmeldungen".
        /// </summary>
        /// <param name="profilID"></param>
        /// <param name="abwPraemienadresse"></param>
        /// <param name="empfaengerAbw"></param>
        /// <param name="empfaengerZusatzAbw"></param>
        /// <param name="strasseAbw"></param>
        /// <param name="adressZusatzAbw"></param>
        /// <param name="plzAbw"></param>
        /// <param name="ortAbw"></param>
        
        bool PlusUpdate(int profilID, bool abwPraemienadresse,
                        string empfaengerAbw, string empfaengerZusatzAbw, string strasseAbw, string adressZusatzAbw, string plzAbw,
                        string ortAbw);

        /// <summary>
        /// Gibt an, ob die Anmeldedaten im Datensatz in der Plus-Anmeldetabelle stehen.
        /// </summary>
        /// <param name="profileID"></param>
        /// <returns></returns>
        
        bool PlusAnmeldungInBearbeitung(int profilID);

        /// <summary>
        /// Gibt an das Datum der Anmeldung zurück.
        /// </summary>
        /// <param name="profileID"></param>
        /// <returns></returns>
        
        DateTime GetPlusAnmeldeDatum(int profilID);
    }
}
