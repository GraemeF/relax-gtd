using MbUnit.Framework;
using Relax.AcceptanceTests.TestEntities;

namespace Relax.AcceptanceTests
{
    [TestFixture]
    public class LaunchTestFixture
    {
        [Test]
        public void Application_launches()
        {
            using (RelaxApplication.Launch())
            {
            }
        }
    }
}