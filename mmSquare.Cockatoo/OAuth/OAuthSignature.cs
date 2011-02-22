namespace mmSquare.Cockatoo.OAuth
{
    using Http;

    public class OAuthSignature
    {
        private readonly OAuthDetails oAuthDetails;

        public OAuthSignature(OAuthDetails oAuthDetails)
        {
            this.oAuthDetails = oAuthDetails;
        }

        public OAuthDetails OAuthDetails { get { return oAuthDetails; } }

        public void Sign(HttpRequestDetails httpRequest)
        {
            
        }
    }
}
