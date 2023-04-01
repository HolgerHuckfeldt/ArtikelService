using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using PvKatalogsystem.Types.Interfaces;

namespace Absolute.SolrClient0900
{
    public class SolrQueryDescription<TDoc> where TDoc : ISolrDocument
    {
        private readonly ISolrIndex<TDoc> _index;

        public SolrQueryDescription(ISolrIndex<TDoc> index)
        {
            _index = index;
            DynamicFieldKeys = new LinkedList<KeyValuePair<string, string>>();
            FacetQueries = new LinkedList<SolrFacetQuery>();
            Highlighting = new SolrHighlightingQuery();
            FieldNames = new LinkedList<string>();
            SortFields = new LinkedList<string>();
            FilterQueries = new LinkedList<string>();
            SolrParameters = new Dictionary<string, string>();
            foreach (var name in _index.DocFields.Where(x => _index.IsStoredField(x.Value) && !x.Key.Contains("*") && !x.Key.Equals("FahrzeugId")).Select(x => x.Key))
            {
                FieldNames.Add(name);
            }

        }

        public string Query { get; set; }
        public ICollection<string> FilterQueries { get; set; }
        public string FilterQuery { get; set; }
        public int? StartIndex { get; set; }
        public int? RowCount { get; set; }
        public ICollection<KeyValuePair<string, string>> DynamicFieldKeys { get; private set; }
        public ICollection<SolrFacetQuery> FacetQueries { get; private set; }
        public SolrHighlightingQuery Highlighting { get; private set; }
        public ICollection<string> FieldNames { get; private set; }
        public ICollection<string> SortFields { get; private set; }
        public Dictionary<string, string> SolrParameters { get; set; }

        public void AddSortField(Expression<Func<TDoc, object>> field, SolrSortDirection direction)
        {
            var fieldName = _index.GetFieldName(field);
            if (fieldName != null)
            {
                SortFields.Add(string.Format("{0} {1}", fieldName, direction.ToString().ToLower()));
            }
        }

        public void AddDynamicFieldKey(Expression<Func<TDoc, object>> field, object key)
        {
            var keyString = key != null ? key.ToString() : null;
            if (string.IsNullOrEmpty(keyString))
            {
                return;
            }
            var fieldName = _index.GetFieldName(field);
            if (string.IsNullOrEmpty(fieldName))
            {
                return;
            }
            DynamicFieldKeys.Add(new KeyValuePair<string, string>(fieldName, fieldName.Replace("*", keyString)));
            FieldNames.Add(fieldName.Replace("*", keyString));
        }

        public void AddHighlightingField(Expression<Func<TDoc, object>> field)
        {
            var expression = field.Body as MemberExpression;
            if (expression == null)
            {
                return;
            }
            Highlighting.Fields.Add(expression.Member.Name);
        }

        public void AddHighlightingField(Expression<Func<TDoc, object>> field, string dynamicKey)
        {
            var expression = field.Body as MemberExpression;
            if (expression == null)
            {
                return;
            }
            Highlighting.Fields.Add(expression.Member.Name.Replace("*", dynamicKey));
        }



    }
}
