using Relax.AcceptanceTests.TestEntities;
using Xunit;

namespace Relax.AcceptanceTests
{
    public class LaunchTestFixture
    {
        [Fact]
        public void Application_launches()
        {
            using (RelaxApplication.Launch())
            {
            }
        }
    }
}