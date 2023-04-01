using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface ISuperFlexService
    {
        List<SuperFlexPraemie> GetPraemien(int paketId);
    }
}
