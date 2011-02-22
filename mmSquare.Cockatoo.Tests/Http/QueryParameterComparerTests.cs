namespace mmSquare.Cockatoo.Tests.Http
{
    using Cockatoo.Http;
    using NUnit.Framework;

    [TestFixture]
    public class QueryParameterComparerTests
    {

        [Test]
        public void Should_Return_Negative_When_First_Is_Less_Than_Second_With_Different_Keys()
        {
            var p1 = new QueryParameter("a", "1");
            var p2 = new QueryParameter("b", "2");

            var queryComparer = new QueryParameterComparer();

            Assert.That(queryComparer.Compare(p1, p2), Is.LessThan(0));
        }

        [Test]
        public void Should_Return_Negative_When_First_Is_Less_Than_Second_With_The_Same_Key()
        {
            var p1 = new QueryParameter("a", "1");
            var p2 = new QueryParameter("a", "2");

            var queryComparer = new QueryParameterComparer();

            Assert.That(queryComparer.Compare(p1, p2), Is.LessThan(0));
        }

        [Test]
        public void Should_Return_Positive_When_First_Is_Greater_Than_Second_With_Different_Keys()
        {
            var p1 = new QueryParameter("f", "1");
            var p2 = new QueryParameter("c", "2");

            var queryComparer = new QueryParameterComparer();

            Assert.That(queryComparer.Compare(p1, p2), Is.GreaterThan(0));
        }

        [Test]
        public void Should_Return_Positive_When_First_Is_Greater_Than_Second_With_Same_Key()
        {
            var p1 = new QueryParameter("f", "z");
            var p2 = new QueryParameter("f", "a");

            var queryComparer = new QueryParameterComparer();

            Assert.That(queryComparer.Compare(p1, p2), Is.GreaterThan(0));
        }


        [Test]
        public void Should_Return_Zero_When_Are_Equal()
        {
            var p1 = new QueryParameter("f", "x");
            var p2 = new QueryParameter("f", "x");

            var queryComparer = new QueryParameterComparer();

            Assert.That(queryComparer.Compare(p1, p2), Is.EqualTo(0));
        }
    }
}
