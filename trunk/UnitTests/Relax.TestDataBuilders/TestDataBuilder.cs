namespace Relax.TestDataBuilders
{
    public class TestDataBuilder
    {
        protected static ActionBuilder AnAction
        {
            get { return new ActionBuilder(); }
        }

        protected static WorkspaceBuilder AWorkspace
        {
            get { return new WorkspaceBuilder(); }
        }
    }
}