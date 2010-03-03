using System;
using Moq;
using Relax.Infrastructure.Models;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class ReviewBuilder : BuilderBase<IReview>
    {
        private readonly HorizonOfFocus _horizonOfFocus;
        private readonly DateTime? _lastReviewed;
        private readonly TimeSpan _reviewPeriod;

        public ReviewBuilder()
        {
            _reviewPeriod = TimeSpan.FromDays(7.0);
            _horizonOfFocus = HorizonOfFocus.AreaOfFocus;
        }

        private ReviewBuilder(ReviewBuilder other)
        {
            _reviewPeriod = TimeSpan.FromDays(7.0);
            _horizonOfFocus = HorizonOfFocus.AreaOfFocus;
            _horizonOfFocus = other._horizonOfFocus;
            _lastReviewed = other._lastReviewed;
            _reviewPeriod = other._reviewPeriod;
        }

        protected override void SetupMock(Mock<IReview> mock)
        {
            mock.Setup(x => x.HorizonOfFocus).Returns(_horizonOfFocus);
            mock.Setup(x => x.LastReviewed).Returns(_lastReviewed);
            mock.Setup(x => x.ReviewPeriod).Returns(_reviewPeriod);
        }
    }
}