namespace mmSquare.Cockatoo.Tests.Http
{
    using Cockatoo.Http;
    using NUnit.Framework;

    [TestFixture]
    public class HttpRequestDetailsTests
    {

        [Test]
        public void Should_Construct_Request_Details_From_String_Url()
        {
            var url = "http://svnbook.red-bean.com/en/1.5/svn.basic.repository.html#svn.basic.repository.dia-1";

            var request = new HttpRequestDetails(url);

            Assert.That(request.Uri.ToString(), Is.SameAs(url));
        }
    }
}
