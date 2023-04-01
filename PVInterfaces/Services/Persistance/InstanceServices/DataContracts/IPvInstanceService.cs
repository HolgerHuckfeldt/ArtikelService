using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PVInterfaces.Services.Persistance.InstanceServices.DataContracts
{

    public interface IPvInstanceService
    {
        /// <summary>
        /// Registriert einen Observer z.B. Diagnose Tool
        /// </summary>
       
        void RegisterSessionObserver();

        /// <summary>
        /// Registriert einen Session Holder beim System. Solange mindestens ein Session Holder beim System registriert ist,
        /// werden die Logon Daten des letzten Clients nicht verworfen, auch wenn kein Client mehr am System angemeldet ist.
        /// </summary>
        /// <param name="name"></param>
      
        void RegisterSessionHolder(String name);

        /// <summary>
        /// Registriert einen neuen Session Client. Dieser kann seinen Namen, z.B. "PVKompass" dem Service übergeben.
        /// Bei erfolgreicher Registrierung gibt die Methode "true" zurück. Im Falle einer negativen Response "false" sollte die aktuelle
        /// PVKompass Instanz sofort wieder herunterfahren. Es könnte sich u.U. noch eine andere Instance im Logon befinden.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       
        bool RegisterSessionClient(String name);

        /// <summary>
        /// Ruft die ggf. gesetzten Logon Daten des Systems ab. Werden keine Daten zurückgegeben, muss der Client
        /// ein Logon durchführen und anschließend seine Daten mittels SetSerializedLogonData() an den Service übermitteln.
        /// </summary>
        /// <returns></returns>
       
        String GetSerializedLogonData();

        /// <summary>
        /// Setzt die Logon Daten im System. Diese Methode muss von einem Client aufgerufen werden, wenn er das Logon durchführt,
        /// da sonst solange ein SessionClient beim Server registriert ist keine weiteren Client Instanzen sich in der Session registrieren können.
        /// </summary>
        /// <param name="data"></param>
     
        void SetSerializedLogonData(String data);

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

        /// <summary>
        /// Unregisters a Session Holder
        /// </summary>
     
        void UnregisterSessionHolder();

        /// <summary>
        /// Unregisters a Session Client
        /// </summary>
     
        void UnregisterSessionClient();

        /// <summary>
        /// Unregisters a Session Observer
        /// </summary>
    
        void UnregisterSessionObserver();

        /// <summary>
        /// Muss in Intervallen kleine 10min vom Client aufgerufen werden.
        /// </summary>
       
        void Alive();
    }
}