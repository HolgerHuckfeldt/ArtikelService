using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PvKatalogsystem.Types.DTOs;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IMotorService
    {
        List<Motor> GetMotorList(IEnumerable<int> idList);
        List<Motor> GetMotorListAll();
    }
}
