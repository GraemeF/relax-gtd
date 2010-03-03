using Moq;
using Relax.Infrastructure.Models.Interfaces;

namespace Relax.TestDataBuilders
{
    public class GtdContextBuilder : BuilderBase<IGtdContext>
    {
        private string _description;

        public GtdContextBuilder()
        {
            _description = "Unspecified";
        }

        private GtdContextBuilder(GtdContextBuilder other)
        {
            _description = other._description;
        }

        protected override void SetupMock(Mock<IGtdContext> mock)
        {
            mock.Setup(x => x.Description).Returns(_description);
        }

        public GtdContextBuilder WithDescription(string description)
        {
            return new GtdContextBuilder(this) {_description = description};
        }
    }
}