using Caliburn.Testability.Extensions;
using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    public class ContextPresenterTestFixture
    {
        [Test]
        public void Rename__SetsReadOnlyToFalse()
        {
            var test = new ContextPresenter(new Mock<IGtdContext>().Object);

            test.Rename();

            Assert.IsFalse(test.IsReadOnly);
        }

        [Test]
        public void FinishRename__SetsReadOnlyToTrue()
        {
            var test = new ContextPresenter(new Mock<IGtdContext>().Object);

            test.Rename();
            test.FinishRename();

            Assert.IsTrue(test.IsReadOnly);
        }

        [Test]
        public void AllProperties_WhenChanged_RaisePropertyChanged()
        {
            var test = new ContextPresenter(new Mock<IGtdContext>().Object);
            test.AssertThatAllProperties().Ignoring(x => x.Model).RaiseChangeNotification();
        }
    }
}