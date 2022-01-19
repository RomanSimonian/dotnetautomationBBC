using NUnit.Framework;

namespace TestSolution
{
    [TestFixture]
    public class Class1
    {
        [TestCase("oleksii", 1)]
        [TestCase("vladislav", 0)]
        [TestCase("oleksii", 3)]
        [TestCase("oleksii", 4)]
        [TestCase("oleksii", 5)]
        [TestCase("oleksii", 6)]
        [Test]
        public void Test1(string userName, int expectedUserRoleId)
        {
            Assert.Fail();
        }
    }
}
