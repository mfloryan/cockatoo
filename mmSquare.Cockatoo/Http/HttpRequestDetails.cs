namespace mmSquare.Cockatoo.Http
{
    using System;

    public class HttpRequestDetails
    {
        private readonly HttpHeaderCollection headers = new HttpHeaderCollection();

        private readonly QueryParameterCollection queryParameters = new QueryParameterCollection();

        public HttpRequestDetails(string url)
        {
            Uri = new Uri(url);
        }

        public Uri Uri { get; set; }

        public HttpHeaderCollection Headers { get { return headers; } }

        public QueryParameterCollection QueryParameters { get { return queryParameters; } }

        public string RequestMethod { get; set; }
    }
}
