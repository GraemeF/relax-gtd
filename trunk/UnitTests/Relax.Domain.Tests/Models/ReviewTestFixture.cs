using System;
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
                                                                     typeof (System.ArgumentOutOfRangeException), DateTime.MaxValue,
                                                                     DateTime.UtcNow + TimeSpan.FromHours(1)
                                                                     }
                                                             }
                                                     };
    }
}