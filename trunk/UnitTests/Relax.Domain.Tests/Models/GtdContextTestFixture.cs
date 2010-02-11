using Relax.Domain.Models;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class GtdContextTestFixture
    {
        [Fact]
        public void ToString__ReturnsTitleWithAt()
        {
            var test = new GtdContext {Title = "Hello"};

            Assert.Equal("@Hello", test.ToString());
        }
    }
}