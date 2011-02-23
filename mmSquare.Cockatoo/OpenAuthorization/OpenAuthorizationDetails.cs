namespace mmSquare.Cockatoo.OpenAuthorization
{
    public class OpenAuthorizationDetails
    {
        private readonly string consumerKey;
        
        public string ConsumerKey
        {
            get { return consumerKey; }
        }

        private readonly string consumerSecret;
        
        public string ConsumerSecret
        {
            get { return consumerSecret; }
        }

        public string Token { get; set; }

        public string TokenSecret { get; set; }

        public OpenAuthorizationDetails(string consumerKey, string consumerSecret)
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
        }
    }
}