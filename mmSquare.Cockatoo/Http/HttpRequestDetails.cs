namespace mmSquare.Cockatoo.Http
{
    using System;
    using System.Collections.Generic;

    public class HttpRequestDetails
    {
        private List<HttpHeader> headers = new List<HttpHeader>();
        private List<QueryParameter> queryParameters = new List<QueryParameter>();

        public Uri Uri { get; set; }

        public IList<HttpHeader> Headers { get { return headers; } }

        public IList<QueryParameter> QueryParameters { get { return queryParameters; } }

        public string RequestMethod { get; set; }

    }
}
