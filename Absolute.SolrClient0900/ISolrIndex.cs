using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Linq.Expressions;
using PvKatalogsystem.Types.Interfaces;
using System.Reflection;

namespace Absolute.SolrClient0900
{
    /// <summary>
    /// Interface wird nur für IndexCreator verwendet, wo der Controller nicht wissen muss, welcher Dokumenttyp verwendet wird.
    /// </summary>
    public interface ISolrIndex
    {
        ICollection<SolrCoreInfo> CoreInfos { get; }
        string Name { get; }
    }

    /// <summary>
    /// Interface für Queries bei denen der Dokumenttyp bekannt ist.
    /// </summary>
    /// <typeparam name="TDoc"></typeparam>
    public interface ISolrIndex<TDoc> : ISolrIndex where TDoc : ISolrDocument
    {
        SolrQueryDescription<TDoc> NewQueryDescription();
        SolrQueryBuilder<TDoc> NewQueryBuilder();
        SolrQueryResult<TDoc> Query(SolrQueryDescription<TDoc> queryDesc);
        SolrQueryResult<TDoc> QueryEx(SolrQueryDescription<TDoc> queryDesc);
        SolrQueryResult<TDoc> QueryEx_JSON(SolrQueryDescription<TDoc> queryDesc);
        string GetFieldName(Expression<Func<TDoc, object>> field, string dynamicKey);
        string GetFieldName(Expression<Func<TDoc, object>> field);
        IDictionary<string, PropertyInfo> DocFields {get;}
        bool IsStoredField(PropertyInfo prop);

        bool Initialized { get; }

        void Initialize();
    }

    
}

