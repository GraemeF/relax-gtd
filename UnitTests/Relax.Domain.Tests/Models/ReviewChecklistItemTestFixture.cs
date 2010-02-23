using Caliburn.Testability.Extensions;
using Relax.Domain.Models;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class ReviewChecklistItemTestFixture : TestDataBuilder
    {
        [Fact]
        public void Review_WhenSet_RaisesPropertyChanged()
        {
            IReview newReview = AReview.Build();

            var test = new ReviewChecklistItem();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Review).
                When(() => test.Review = newReview);
            Assert.Same(newReview, test.Review);
        }
    }
}