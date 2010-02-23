using System;
using Caliburn.Testability.Extensions;
using Relax.Domain.Models;
using Relax.Infrastructure.Models;
using Xunit;

namespace Relax.Domain.Tests.Models
{
    public class ReviewTestFixture
    {
        [Fact]
        public void HorizonOfFocus_WhenSet_RaisesPropertyChanged()
        {
            const HorizonOfFocus newHorizon = HorizonOfFocus.Project;

            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.HorizonOfFocus).
                When(() => test.HorizonOfFocus = newHorizon);
            Assert.Equal(newHorizon, test.HorizonOfFocus);
        }

        [Fact]
        public void LastReviewed_WhenSet_RaisesPropertyChanged()
        {
            DateTime newLastReviewed = DateTime.Today.ToUniversalTime();

            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.LastReviewed).
                When(() => test.LastReviewed = newLastReviewed);
            Assert.Equal(newLastReviewed, test.LastReviewed);
        }

        [Fact]
        public void LastReviewed_WhenSetToFuture_Throws()
        {
            var test = new Review();

            Assert.Throws(typeof (ArgumentOutOfRangeException),
                          () => test.LastReviewed = DateTime.UtcNow + TimeSpan.FromDays(5.0));
        }

        [Fact]
        public void ReviewPeriod_WhenSet_RaisesPropertyChanged()
        {
            TimeSpan newReviewPeriod = TimeSpan.FromDays(7);

            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.ReviewPeriod).
                When(() => test.ReviewPeriod = newReviewPeriod);
            Assert.Equal(newReviewPeriod, test.ReviewPeriod);
        }

        [Fact]
        public void PropertyChanged_RemoveHandler_()
        {
            // AssertThatChangeNotificationIsRaisedBy doesn't seem to remove
            // handlers so this is just to get 100% coverage.
            var test = new Review();

            test.PropertyChanged += delegate { };
            test.PropertyChanged -= delegate { };
        }
    }
}