using PvKatalogsystem.Types.DTOs;
using PvKatalogsystem.Types.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PvKatalogsystem.Types.Interfaces
{
    public interface IMappedListService<T_SolrDoc, T_Dto> 
        where T_SolrDoc : ISolrDocument 
        where T_Dto : DtoBase
    {
        List<T_Dto> GetList(IEnumerable<int> idList);
        List<T_Dto> GetListAll();

        List<T_Dto> GetListEx(IEnumerable<int> idList);
        List<T_Dto> GetListAllEx();
    }
}
