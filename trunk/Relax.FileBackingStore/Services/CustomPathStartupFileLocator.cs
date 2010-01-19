using Relax.FileBackingStore.Services.Interfaces;

namespace Relax.FileBackingStore.Services
{
    public class CustomPathStartupFileLocator : IStartupFileLocator
    {
        public CustomPathStartupFileLocator(string path)
        {
            Path = path;
            LoadOnStartup = true;
        }

        #region IStartupFileLocator Members

        public string Path { get; private set; }

        public bool LoadOnStartup { get; set; }

        #endregion
    }
}