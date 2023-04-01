using PV.DomainObjects.Mail.Smtp;


namespace PV.Persistance.Provider
{
    /// <summary>
    /// Providerschnittstelle 
    /// </summary>
    
    public interface ISmtpProvider
    {
        /// <summary>
        /// Sendet eine Smtp-Nachricht.
        /// </summary>
        /// <param name="_toSend">Die zu sendende Nachricht</param>
        /// <returns>true bei Erfolg, sonst false</returns>
        
        bool Send(SmtpMessage _toSend);
    }
}
