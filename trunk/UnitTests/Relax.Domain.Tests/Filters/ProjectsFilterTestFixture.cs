using Relax.Domain.Filters;
using Relax.Infrastructure.Models.Interfaces;
using Relax.TestDataBuilders;
using Xunit;

namespace Relax.Domain.Tests.Filters
{
    public class ProjectsFilterTestFixture : TestDataBuilder
    {
        [Fact]
        public void Actions_WhenWorkspaceContainsAnActionThatIsBlockedButNotBlocking_ContainsAction()
        {
            IAction unblockedAction = AnAction.Build();
            IAction blockedAction = AnAction.BlockedBy(unblockedAction).Build();
            var test = new ProjectsFilter(AWorkspace.With(blockedAction).
                                              With(unblockedAction).Build());

            Assert.Contains(blockedAction, test.Actions);
            Assert.Equal(1, test.Actions.Count);
        }
    }
}