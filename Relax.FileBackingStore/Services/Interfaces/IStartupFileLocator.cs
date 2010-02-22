namespace Relax.FileBackingStore.Services.Interfaces
{
    public interface IStartupFileLocator : IFileLocator
    {
        bool LoadOnStartup { get; }
    }
}