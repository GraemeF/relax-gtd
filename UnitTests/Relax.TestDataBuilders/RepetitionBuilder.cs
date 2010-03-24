using Moq;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class RepetitionBuilder : BuilderBase<IRepetition>
    {
        public RepetitionBuilder()
        {
        }

        private RepetitionBuilder(RepetitionBuilder other)
        {
        }

        protected override void SetupMock(Mock<IRepetition> mock)
        {
        }
    }
}