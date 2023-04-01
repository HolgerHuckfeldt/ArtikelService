using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface ICmsService
    {
        //CmsDto GetAktuellUndWichtig();

        String GetHeaderTexte();

        Dictionary<string, string> GetPvPlusText();

        byte[] GetStandortLogo(int firmaID, int standortID);
    }
}
