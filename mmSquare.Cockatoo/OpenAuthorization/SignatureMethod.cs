namespace mmSquare.Cockatoo.OpenAuthorization
{
    public class SignatureMethod
    {
        /// <summary>HMAC: Keyed-Hashing for Message Authentication [RFC2104]</summary>
        public const string HmacSha1 = "HMACSHA1";

        /// <summary>PLAINTEXT method does not employ a signature algorithm.</summary>
        public const string Plaintext = "PLAINTEXT";

        /// <summary>RSASSA-PKCS1-v1_5 signature algorithm [RFC3447 8.2]</summary>
        public const  string RsaSha1 = "RSASHA1";
    }
}
