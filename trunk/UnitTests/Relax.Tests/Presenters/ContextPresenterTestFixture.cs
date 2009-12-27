﻿using MbUnit.Framework;
using Moq;
using Relax.Infrastructure.Models.Interfaces;
using Relax.Presenters;

namespace Relax.Tests.Presenters
{
    [TestFixture]
    [Ignore]
    public class ContextPresenterTestFixture
    {
        private const string TestTitle = "Test Title";

        [Test]
        public void DisplayNameGet__ReturnsModelTitle()
        {
            var stubContext = new Mock<IGtdContext>();
            stubContext.Setup(x => x.Title).Returns(TestTitle);

            var test = new ContextPresenter(stubContext.Object);

            Assert.AreEqual(TestTitle, test.DisplayName);
        }

        [Test]
        public void DisplayNameSet__UpdatesModelTitle()
        {
            var mockContext = new Mock<IGtdContext>();

            new ContextPresenter(mockContext.Object) {DisplayName = TestTitle};

            mockContext.VerifySet(x => x.Title = TestTitle);
        }

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
    }
}