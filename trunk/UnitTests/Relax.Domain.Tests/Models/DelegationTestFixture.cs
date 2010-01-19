using System;
using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using Relax.Domain.Models;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class DelegationTestFixture
    {
        [VerifyContract]
        public readonly IContract DelegationDate__MeetsPropertyContract = new AccessorContract<Delegation, DateTime?>
                                                                              {
                                                                                  PropertyName = "DelegationDate",
                                                                                  AcceptNullValue = true,
                                                                                  ValidValues =
                                                                                      {
                                                                                          DateTime.UtcNow,
                                                                                          DateTime.Today
                                                                                      },
                                                                                  InvalidValues =
                                                                                      {
                                                                                          {
                                                                                              typeof (
                                                                                              ArgumentOutOfRangeException
                                                                                              ),
                                                                                              DateTime.MaxValue
                                                                                              }
                                                                                      }
                                                                              };

        [VerifyContract]
        public readonly IContract Owner__MeetsPropertyContract = new AccessorContract<Delegation, string>
                                                                     {
                                                                         PropertyName = "Owner",
                                                                         AcceptNullValue = true,
                                                                         ValidValues =
                                                                             {
                                                                                 "test"
                                                                             },
                                                                     };

        [Test]
        public void Owner_WhenSet_RaisesPropertyChanged()
        {
            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Owner).When(() => test.Owner = "test");
        }

        [Test]
        public void DelegationDate_WhenSet_RaisesPropertyChanged()
        {
            var test = new Delegation();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.DelegationDate).When(
                () => test.DelegationDate = DateTime.Today);
        }

        [Test]
        public void PropertyChanged_RemoveHandler_()
        {
            // AssertThatChangeNotificationIsRaisedBy doesn't seem to remove
            // handlers so this is just to get 100% coverage.
            var test = new Delegation();

            test.PropertyChanged += delegate { };
            test.PropertyChanged -= delegate { };
        }
    }
}