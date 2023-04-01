using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Enums;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface ISendEmail
    {
        bool SendBestellbestätigungEmail(ServiceContext context, byte[] fileContents, BestellbestätigungTyp bestellbestätigungTyp);
    }
}
