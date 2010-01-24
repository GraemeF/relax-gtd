using MbUnit.Framework;
using Relax.Domain.Filters;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;

namespace Relax.Domain.Tests.Filters
{
    [TestFixture]
    public class ProjectsFilterTestFixture : TestDataBuilder
    {
        [Test]
        public void Actions_WhenWorkspaceContainsAnActionThatIsBlockedButNotBlocking_ContainsAction()
        {
            IAction unblockedAction = AnAction.Build();
            IAction blockedAction = AnAction.BlockedBy(unblockedAction).Build();
            var test =
                new ProjectsFilter(AWorkspace.With(blockedAction).With(unblockedAction).Build());

            Assert.AreElementsEqual(new[] {blockedAction}, test.Actions);
        }
    }
}