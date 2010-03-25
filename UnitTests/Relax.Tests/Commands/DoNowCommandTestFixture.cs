using System;
using Moq;
using Relax.Commands;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Tests.Commands
{
    public class DoNowCommandTestFixture : TestDataBuilder
    {
        [Fact]
        public void Execute__MarksActionAsCompleted()
        {
            DateTime timeAtStart = DateTime.UtcNow;
            Mock<IAction> mockAction = AnAction.Mock();

            var test = new DoNowCommand();
            test.Execute(mockAction.Object);

            mockAction.VerifySet(x => x.CompletedDate = It.IsInRange(timeAtStart, DateTime.UtcNow, Range.Inclusive));
        }

        [Fact]
        public void CanExecute_WhenGivenAnAction_ReturnsTrue()
        {
            Assert.True(new DoNowCommand().CanExecute(AnAction.Build()));
        }

        [Fact]
        public void CanExecute_WhenNotGivenAnAction_ReturnsFalse()
        {
            Assert.False(new DoNowCommand().CanExecute(null));
        }
    }
}