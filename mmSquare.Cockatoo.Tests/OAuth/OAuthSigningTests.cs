namespace mmSquare.Cockatoo.Tests.OAuth
{
    using System.Linq;
    using Cockatoo.Http;
    using Cockatoo.OAuth;
    using NUnit.Framework;

    [TestFixture]
    public class OAuthSigningTests
    {

        [Test]
        public void Should_Sign_Example_Request_Details_From_Specification()
        {
            string url = "http://photos.example.net/photos";
            string parameters = "size=original, file=vacation.jpg";
            string consumerKey = "dpf43f3p2l4k3l03";
            string consumerSecret = "kd94hf93k423kf44";
            string token = "nnch734d00sl2jdk";
            string tokenSecret = "pfkkdhi9sl3r4s00";
            string nonce = "kllo9940pd9333jh";
            string timestamp = "1191242096";

            var authDetails = new OAuthDetails();

            var signature = new OAuthSignature(authDetails);
            var httpRequest = new HttpRequestDetails();

            var signedRequest = signature.Sign(httpRequest);

            var header = signedRequest.Headers.First(h => h.Field == HttpHeader.KnownHeaders.Authorization);
            
            const string EXPECTED_HEADER = "OAuth realm=\"http://photos.example.net/photos\", oauth_consumer_key=\"dpf43f3p2l4k3l03\", oauth_token=\"nnch734d00sl2jdk\", oauth_nonce=\"kllo9940pd9333jh\", oauth_timestamp=\"1191242096\", oauth_signature_method=\"HMAC-SHA1\", oauth_version=\"1.0\", oauth_signature=\"tR3%2BTy81lMeYAr%2FFid0kMTYa%2FWM%3D\"";
            Assert.That(header.Value, Is.EqualTo(EXPECTED_HEADER));
        }
    }
}
