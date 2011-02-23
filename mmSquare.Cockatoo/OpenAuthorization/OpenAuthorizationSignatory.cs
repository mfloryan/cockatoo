using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace mmSquare.Cockatoo.OpenAuthorization
{
    using Http;

    public class OpenAuthorizationSignatory
    {
        private readonly OpenAuthorizationDetails openAuthorizationDetails;

        public OpenAuthorizationSignatory(OpenAuthorizationDetails openAuthorizationDetails)
        {
            this.openAuthorizationDetails = openAuthorizationDetails;
        }

        public OpenAuthorizationDetails OpenAuthorizationDetails { get { return openAuthorizationDetails; } }

        public HttpHeader Sign(HttpRequestDetails httpRequest)
        {
            return Sign(httpRequest, GenerateNonce(), GenerateTimestamp());
        }

        public HttpHeader Sign(HttpRequestDetails httpRequest, string nonce, string timestamp)
        {
            return new HttpHeader(HttpHeader.KnownHeaders.Authorization, GenerateOpenAuthorization(httpRequest, SignatureMethod.HmacSha1, nonce, timestamp));
        }
        
        protected const string OAuthVersion = "1.0";

        protected const string OAuthConsumerKeyKey = "oauth_consumer_key";
        protected const string OAuthCallbackKey = "oauth_callback";
        protected const string OAuthVersionKey = "oauth_version";
        protected const string OAuthSignatureMethodKey = "oauth_signature_method";
        protected const string OAuthSignatureKey = "oauth_signature";
        protected const string OAuthTimestampKey = "oauth_timestamp";
        protected const string OAuthNonceKey = "oauth_nonce";
        protected const string OAuthTokenKey = "oauth_token";
        protected const string OAuthTokenSecretKey = "oauth_token_secret";

        private string GenerateOpenAuthorization(HttpRequestDetails httpRequest, string signatureMethod, string nonce, string timestamp)
        {
            QueryParameterCollection signatureParameters = new QueryParameterCollection();
            
            foreach (var queryParameter in httpRequest.QueryParameters)
            {
                signatureParameters.Add(queryParameter);
            }

            signatureParameters.Add(new QueryParameter(OAuthVersionKey, OAuthVersion));
            signatureParameters.Add(new QueryParameter(OAuthNonceKey, nonce));
            signatureParameters.Add(new QueryParameter(OAuthTimestampKey, timestamp));
            signatureParameters.Add(new QueryParameter(OAuthSignatureMethodKey, signatureMethod));
            signatureParameters.Add(new QueryParameter(OAuthConsumerKeyKey, openAuthorizationDetails.ConsumerKey));

            return string.Empty;

        }

        private string GenerateSignature(string signatureMethod, string signatureBase)
        {
            switch (signatureMethod)
            {
                case SignatureMethod.Plaintext:
                    return
                        HttpUtility.HtmlEncode(
                            string.Format(
                                "{0}&{1}", 
                                openAuthorizationDetails.ConsumerSecret,
                                openAuthorizationDetails.TokenSecret));
                case SignatureMethod.HmacSha1:
                    return Convert.ToBase64String(
                            new HMACSHA1().ComputeHash(
                                Encoding.ASCII.GetBytes(signatureBase)));
                default:

                    throw new ArgumentOutOfRangeException("signatureMethod");
            }
        }
        
        private string GenerateNonce()
        {
            return Guid.NewGuid().ToString();
        }

        private string GenerateTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private class QuotedString
        {
            private readonly string text;

            public QuotedString(string text)
            {
                this.text = text;
            }

            public static implicit operator string(QuotedString quotedString)
            {
                return quotedString.ToString();
            }

            public override string ToString()
            {
                return string.Format("\"{0}\"", text);
            }
        }

    }
}
