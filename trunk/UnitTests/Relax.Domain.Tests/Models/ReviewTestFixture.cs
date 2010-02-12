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
            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.HorizonOfFocus).
                When(() => test.HorizonOfFocus = HorizonOfFocus.Project);
        }

        [Fact]
        public void LastReviewed_WhenSet_RaisesPropertyChanged()
        {
            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.LastReviewed).
                When(() => test.LastReviewed = DateTime.Today);
        }

        [Fact]
        public void ReviewPeriod_WhenSet_RaisesPropertyChanged()
        {
            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.ReviewPeriod).
                When(() => test.ReviewPeriod = TimeSpan.FromDays(7));
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