namespace mmSquare.Cockatoo.Http
{
    using System.Collections.Generic;

    public class QueryParameterComparer : IComparer<QueryParameter>
    {
        public int Compare(QueryParameter x, QueryParameter y)
        {
            if (x.Key.CompareTo(y.Key) == 0)
            {
                return x.Value.CompareTo(y.Value);
            }

            return x.Key.CompareTo(y.Key);
        }
    }
}
