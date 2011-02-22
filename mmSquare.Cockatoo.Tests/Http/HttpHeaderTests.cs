namespace mmSquare.Cockatoo.Tests.Http
{
    using Cockatoo.Http;
    using System;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class HttpHeaderTests
    {

        [Test]
        public void Should_Create_Simple_Header_With_Given_Single_Value()
        {
            const string SOME_FIELD = "Transfer-Encoding";
            const string SOME_VALUE = "chunked";

            var header = new HttpHeader(SOME_FIELD, SOME_VALUE);

            Assert.That(header.Field, Is.EqualTo(SOME_FIELD));
            Assert.That(header.Value, Is.EqualTo(SOME_VALUE));
            Assert.That(header.Values.Count(), Is.EqualTo(1));
            Assert.That(header.ToString(), Is.EqualTo("Transfer-Encoding: chunked"));
        }

        [Test]
        public void Can_Add_Additional_Values()
        {
            const string SOME_FIELD = "Authorization";

            var header = new HttpHeader(SOME_FIELD, "OAuth realm=\"http://photos.example.net/photos\"");
            header.AddValue("oauth_consumer_key=\"dpf43f3p2l4k3l03\"");

            Assert.That(header.Value, Is.EqualTo("OAuth realm=\"http://photos.example.net/photos\", oauth_consumer_key=\"dpf43f3p2l4k3l03\""));
        }

        [Test]
        public void Can_Create_Know_Header()
        {
            var header = new HttpHeader(HttpHeader.KnownHeaders.Authorization, "test");
            Assert.That(header.Field, Is.EqualTo("Authorization"));
        }

        [Test]
        public void Should_Throw_Exception_On_Construction_If_Field_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new HttpHeader(null, "value"));
        }

        [Test]
        public void Should_Throw_Exception_On_Construction_If_Field_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new HttpHeader(string.Empty, "value"));
        }

        [Test]
        public void Should_Throw_Exception_On_Construction_If_Value_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new HttpHeader(HttpHeader.KnownHeaders.Age, null));
        }

        [Test]
        public void Should_Throw_Exception_On_Construction_If_Value_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new HttpHeader(HttpHeader.KnownHeaders.Age, string.Empty));
        }

    }
}
