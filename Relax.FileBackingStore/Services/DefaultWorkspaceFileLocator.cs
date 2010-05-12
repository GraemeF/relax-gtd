using System;
using Caliburn.Core.IoC;
using Relax.FileBackingStore.Services.Interfaces;

namespace Relax.FileBackingStore.Services
{
    [PerRequest(typeof (IStartupFileLocator))]
    public class DefaultWorkspaceFileLocator : IStartupFileLocator
    {
        public static string DefaultBackingStorePath
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                              @"Relax-GTD\Workspace.xml");
            }
        }

        #region IStartupFileLocator Members

        public string Path
        {
            get { return DefaultBackingStorePath; }
        }

        public bool LoadOnStartup
        {
            get { return true; }
        }

        #endregion
    }
}