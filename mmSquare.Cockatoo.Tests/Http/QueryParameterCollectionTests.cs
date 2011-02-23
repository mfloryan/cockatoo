namespace mmSquare.Cockatoo.Tests.Http
{
    using Cockatoo.Http;
    using NUnit.Framework;

    public class QueryParameterCollectionTests
    {

        [Test]
        public void Can_Create_Empty_Parameter_Collection()
        {
            var pc = new QueryParameterCollection();
            Assert.That(pc, Is.Not.Null);
        }

        [Test]
        public void Can_Add_Parameter_To_Collection()
        {
            var pc = new QueryParameterCollection();
            pc.Add("file", "lenny.jpg");

            Assert.That(pc.Count, Is.EqualTo(1));

            var p1 = pc[0];
            
            Assert.That(p1.Key, Is.EqualTo("file"));
            Assert.That(p1.Value, Is.EqualTo("lenny.jpg"));
        }
    }
}
