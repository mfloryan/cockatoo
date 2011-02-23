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

        public HttpRequestDetails Sign(HttpRequestDetails httpRequest)
        {
            return null;
        }
    }
}
