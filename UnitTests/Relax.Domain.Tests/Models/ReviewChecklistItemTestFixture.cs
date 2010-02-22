using Caliburn.Testability.Extensions;
using Moq;
using Relax.Domain.Models;
using Relax.Infrastructure.Models.Interfaces;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class ReviewChecklistItemTestFixture
    {
        [Fact]
        public void Review_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Review).
                When(() => test.Review = new Mock<IReview>().Object);
        }
    }
}