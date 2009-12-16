using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using Moq;
using Relax.Domain.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.Domain.Tests.Models
{
    [TestFixture]
    public class ReviewChecklistItemTestFixture
    {
        [VerifyContract]
        public readonly IContract Review__MeetsPropertyContract = new AccessorContract<ReviewChecklistItem, IReview>
                                                                      {
                                                                          PropertyName = "Review",
                                                                          AcceptNullValue = true,
                                                                          ValidValues =
                                                                              {
                                                                                  new Mock<IReview>().Object
                                                                              }
                                                                      };

        [Test]
        public void Review_WhenSet_RaisesPropertyChanged()
        {
            var test = new Action();

            test.AssertThatChangeNotificationIsRaisedBy(x => x.Review).When(() => test.Review = new Mock<IReview>().Object);
        }
    }
}