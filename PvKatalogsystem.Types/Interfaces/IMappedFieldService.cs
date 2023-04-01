using PvKatalogsystem.Types.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IMappedFieldService//<T_Dto> // where T_Dto : DtoBase
    {
        List<T> GetMappedList<T>(string fieldName, Func<string, T> mappingAction);
        List<T> GetMappedListEx<T>(string fieldName, Func<string, T> mappingAction);
    }
}
