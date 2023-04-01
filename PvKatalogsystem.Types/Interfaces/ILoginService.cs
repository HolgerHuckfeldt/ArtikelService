using PvKatalogsystem.Types.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface ILoginService
    {
        bool CheckContext(ServiceContext context, string md5Hash);
        string CreateHash(ServiceContext context);
        ServiceContext DoLogin(string md5Hash);
        ServiceContext GetProfilByProfilHash(string profilHash);
    }
}
