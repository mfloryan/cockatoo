namespace mmSquare.Cockatoo.Http
{
    using System;

    public class QueryParameter : IComparable<QueryParameter>
    {
        private static readonly QueryParameterComparer Comparer = new QueryParameterComparer();
        private readonly string key;
        private readonly string value;

        public QueryParameter(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string Key { get { return key; } }

        public string Value { get { return value; } }
        
        public int CompareTo(QueryParameter other)
        {
            return Comparer.Compare(this, other);
        }
    }
}
