using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using Relax.Domain.Models;
using Relax.Infrastructure.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class ReviewTestFixture
    {
        [VerifyContract]
        public readonly IContract HorizonOfFocus = new AccessorContract<Review, HorizonOfFocus>
                                                       {
                                                           PropertyName = "HorizonOfFocus",
                                                           AcceptNullValue = false,
                                                           ValidValues =
                                                               {
                                                                   Infrastructure.Models.HorizonOfFocus.Project,
                                                                   Infrastructure.Models.HorizonOfFocus.AreaOfFocus
                                                               }
                                                       };

        [VerifyContract]
        public readonly IContract LastReviewed = new AccessorContract<Review, DateTime?>
                                                     {
                                                         PropertyName = "LastReviewed",
                                                         AcceptNullValue = true,
                                                         ValidValues = {DateTime.Today, DateTime.UtcNow},
                                                         InvalidValues =
                                                             {
                                                                 {
                                                                     typeof (ArgumentOutOfRangeException), DateTime.MaxValue,
                                                                     DateTime.UtcNow + TimeSpan.FromHours(1)
                                                                     }
                                                             }
                                                     };

        [VerifyContract]
        public readonly IContract ReviewPeriod = new AccessorContract<Review, TimeSpan>
                                                     {
                                                         PropertyName = "ReviewPeriod",
                                                         AcceptNullValue = false,
                                                         ValidValues = {TimeSpan.FromDays(7)}
                                                     };

        [Test]
        public void HorizonOfFocus_WhenSet_RaisesPropertyChanged()
        {
            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.HorizonOfFocus).When(
                () => test.HorizonOfFocus = Infrastructure.Models.HorizonOfFocus.Project);
        }

        [Test]
        public void LastReviewed_WhenSet_RaisesPropertyChanged()
        {
            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.LastReviewed).When(() => test.LastReviewed = DateTime.Today);
        }

        [Test]
        public void ReviewPeriod_WhenSet_RaisesPropertyChanged()
        {
            var test = new Review();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.ReviewPeriod).When(() => test.ReviewPeriod = TimeSpan.FromDays(7));
        }

        [Test]
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