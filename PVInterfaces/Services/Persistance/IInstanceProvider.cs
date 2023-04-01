using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PV.Persistance.Provider
{
    public interface IInstanceProvider
    {
        /// <summary>
        /// Setzt die Logon Daten des Client beim lokalen Dienst
        /// </summary>
        /// <returns></returns>
        String GetSerializedLogonData();

        /// <summary>
        /// Holt die Logon Daten des Client beim lokalen Dienst
        /// </summary>
        /// <param name="data"></param>
        void SetSerializedLogonData(String data);
        
        /// <summary>
        /// Wenn "false", muss Kompass sofort wieder herunterfahren
        /// </summary>
        Boolean RegisteredSuccessful{ get; }

        /// <summary>
        /// Speichert den letzten User in eine Datei
        /// </summary>
        /// <param name="_username">Der zu speichernde Nutzernamen</param>
        void SaveLastUserToFile(string _username);

        /// <summary>
        /// Liest den Namen des letzten Users aus einer Datei
        /// </summary>
        /// <returns>Der Username des zuletzt eingeloggten Users, sonst null</returns>
        string ReadLastUserFromFile();

        /// <summary>
        /// Speichert die Passworte der User welche dieses aktiviert haben in eine lokale Datei
        /// </summary>
        void SaveUserPasswordsToFile(Dictionary<String, String> passwords);

        /// <summary>
        /// Liest die Passworte der User welche dieses aktiviert haben aus einer lokalen Datei
        /// </summary>
        /// <returns>Ein Dictionary mit Usernamen und Passworten</returns>
        Dictionary<string, string> ReadUserPasswordsFromFile();

        /// <summary>
        /// Speichert das letzte Profil des Current Users in eine Datei
        /// </summary>
        /// <param name="_profil">Das zu speichernde Profil</param>
        void SetUserprofilToFile(string _profil);

    }
}
