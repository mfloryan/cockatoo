using System;
using System.Collections.Generic;
using System.Globalization;

namespace mmSquare.Cockatoo.Http
{
    public class HttpHeader
    {
        
        public static class KnownHeaders
        {
            public const string Accept = "Accept";
            public const string AcceptCharset = "Accept-Charset";
            public const string Age = "Age";
            public const string Authorization = "Authorization";
        }
        
        private readonly string field;
        private readonly List<string> values = new List<string>();

        public HttpHeader(string field, string value)
        {
            if (field == null) throw new ArgumentNullException("field");
            if (field == string.Empty) throw new ArgumentException("field");
            if (value == null) throw new ArgumentNullException("value");
            if (value == string.Empty) throw new ArgumentException("value");
            this.field = field;
            values.Add(value);
        }

        public string Field { get { return field;  } }

        public IEnumerable<string> Values { get { return values.AsReadOnly(); } }

        public string Value
        {
            get { return string.Join(", ", values); }
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}: {1}", Field, Value);
        }

        public void AddValue(string value)
        {
            values.Add(value);
        }
    }
}
