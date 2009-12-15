using MbUnit.Framework;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class WorkspaceTestFixture
    {
        [Test]
        public void Contexts_Initially_Contains3Items()
        {
            var test = new Workspace();

            Assert.AreEqual(3, test.Contexts.Count);
        }
    }
}