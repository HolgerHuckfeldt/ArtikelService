using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IVdbCache
    {
        VdbLoginResponse FindLogin(VdbUserInfo userInfo);
        void AddLogin(VdbUserInfo userInfo, VdbLoginResponse login);

        KontoInfos FindKontoInfos(VdbUserInfo userInfo);
        void AddKontoInfos(VdbUserInfo userInfo, KontoInfos kontoInfos);

        VdbArtikelinformationen FindArtikelInfo(VdbUserInfo userInfo, int artikelId);
        void AddArtikelInfo(VdbUserInfo userInfo, int artikelId, VdbArtikelinformationen artikelInfo);
    }
}
