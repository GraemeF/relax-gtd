using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Automation;
using MbUnit.Framework;

namespace Relax.AcceptanceTests.TestEntities
{
    public class RelaxApplication : IDisposable
    {
        private readonly Process _process;
        private readonly AutomationElement _shell;
        private static readonly TimeSpan StartUpTimeout = new TimeSpan(0, 0, 10);

        #region Path to the Relax app.

#if DEBUG
        private const string Configuration = "Debug";
#else
        private const string Configuration = "Release";
#endif
        private const string ApplicationPath = @"..\..\..\..\bin\" + Configuration + @"\Relax.exe";

        #endregion

        /// <summary>
        /// Launches an instance of Relax for testing.
        /// </summary>
        /// <returns>The launched instance.</returns>
        public static RelaxApplication Launch(bool newWorkspace, string workspacePath)
        {
            var args = new StringBuilder();
            if (newWorkspace)
                args.Append(" /n");
            if (workspacePath != null)
                args.AppendFormat(" /workspace=\"{0}\"", workspacePath);

            var startInfo = new ProcessStartInfo(ApplicationPath, args.ToString()) {UseShellExecute = false};
            Process process = Process.Start(startInfo);

            AutomationElement desktop = AutomationElement.RootElement;
            AutomationElement shell = null;

            Retry.WithFailureMessage("Relax Monitor did not connect.")
                .WithTimeout(StartUpTimeout)
                .Until(delegate
                           {
                               shell = desktop.FindFirst(TreeScope.Children,
                                                         new PropertyCondition(
                                                             AutomationElement.NameProperty,
                                                             "Relax GTD"));

                               return process.HasExited || shell != null;
                           });

            if (shell == null)
            {
                process.Dispose();
                throw new Exception("Failed to find Relax.");
            }

            return new RelaxApplication(process, shell);
        }

        /// <summary>
        /// Launches an instance of Relax for testing.
        /// </summary>
        /// <returns>The launched instance.</returns>
        public static RelaxApplication Launch(string workspacePath)
        {
            return Launch(false, workspacePath);
        }

        /// <summary>
        /// Launches an instance of Relax for testing.
        /// </summary>
        /// <returns>The launched instance.</returns>
        public static RelaxApplication Launch()
        {
            return Launch(true);
        }

        /// <summary>
        /// Launches an instance of Relax for testing.
        /// </summary>
        /// <returns>The launched instance.</returns>
        public static RelaxApplication Launch(bool newWorkspace)
        {
            return Launch(newWorkspace, null);
        }

        private RelaxApplication(Process process, AutomationElement shell)
        {
            _process = process;
            _shell = shell;
        }

        /// <summary>
        /// Gets the shell window.
        /// </summary>
        /// <value>The shell window.</value>
        public Shell Shell
        {
            get { return new Shell(_shell); }
        }

        private static string DefaultWorkspaceFilePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                    @"Relax\Relax.xml");
            }
        }

        public static FileInfo DefaultWorkspaceFile
        {
            get { return new FileInfo(DefaultWorkspaceFilePath); }
        }

        /// <summary>
        /// Releases all resources used by an instance of the <see cref="RelaxApplication" /> class.
        /// </summary>
        /// <remarks>
        /// This method calls the virtual <see cref="Dispose(bool)" /> method, passing in <strong>true</strong>, and then suppresses 
        /// finalization of the instance.
        /// </remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged resources before an instance of the <see cref="RelaxApplication" /> class is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>
        /// This method releases unmanaged resources by calling the virtual <see cref="Dispose(bool)" /> method, passing in <strong>false</strong>.
        /// </remarks>
        ~RelaxApplication()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases the unmanaged resources used by an instance of the <see cref="RelaxApplication" /> class and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><strong>true</strong> to release both managed and unmanaged resources; <strong>false</strong> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _process.CloseMainWindow();
                _process.Dispose();
            }
        }

        public void StartCollectingActions()
        {
            Shell.CollectButton.Click();
        }

        public void AddInboxAction(string newAction)
        {
            _shell.FindDescendentByIdPath(new[] {"Collect", "Input", "Title"}).SetValue(newAction);
            _shell.FindDescendentByIdPath(new[] {"Collect", "Input", "Add"}).GetInvokePattern().Invoke();
        }

        public void HasInboxActions(IEnumerable<string> actions)
        {
            Assert.AreElementsEqualIgnoringOrder(actions,
                                                 Shell.CollectActivity.ActionList.Actions);
        }
    }
}