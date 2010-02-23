using Caliburn.Testability.Extensions;
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

        [Fact]
        public void Description_WhenSet_RaisesPropertyChanged()
        {
            const string newDescription = "New description";

            var test = new GtdContext();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Description).
                When(() => test.Description = newDescription);
            Assert.Equal(newDescription, test.Description);
        }
    }
}