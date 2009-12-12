using MbUnit.Framework;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class ActionTestFixture
    {
        [Test]
        public void TitleSet__UpdatesTitle()
        {
            var test = new Action();

            test.Title = "test title";

            Assert.AreEqual("test title", test.Title);
        }
    }
}