using Moq;
using Relax.Presenters;
using Relax.Presenters.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Presenters
{
    public class ProcessActionPresenterTestFixture : TestDataBuilder
    {
        private readonly Mock<IDoLaterPresenter> _stubDoLater = new Mock<IDoLaterPresenter>();
        private readonly Mock<IDoNowPresenter> _stubDoNow = new Mock<IDoNowPresenter>();

        private ProcessActionPresenter BuildDefaultProcessActionPresenter()
        {
            return new ProcessActionPresenter(AnAction.Build(), _stubDoNow.Object, _stubDoLater.Object);
        }

        [Fact]
        public void DoLater__ReturnsDoLaterPresenter()
        {
            ProcessActionPresenter test = BuildDefaultProcessActionPresenter();

            Assert.Same(_stubDoLater.Object, test.DoLater);
        }

        [Fact]
        public void DoNow__ReturnsDoNowPresenter()
        {
            ProcessActionPresenter test = BuildDefaultProcessActionPresenter();

            Assert.Same(_stubDoNow.Object, test.DoNow);
        }
    }
}