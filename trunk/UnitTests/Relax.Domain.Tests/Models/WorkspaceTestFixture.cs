using MbUnit.Framework;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class WorkspaceTestFixture
    {
        [Test]
        public void Contexts_Initially_IsEmpty()
        {
            var test = new Workspace();

            Assert.IsEmpty(test.Contexts);
        }
    }
}