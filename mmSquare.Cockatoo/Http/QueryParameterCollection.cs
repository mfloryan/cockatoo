namespace mmSquare.Cockatoo.Http
{
    using System.Collections.Generic;

    public class QueryParameterCollection : BaseListCollection<QueryParameter>
    {
        private readonly List<QueryParameter> queryParameters = new List<QueryParameter>();

        public void Add(string key, string value)
        {
            queryParameters.Add(new QueryParameter(key, value));
        }
    }
}