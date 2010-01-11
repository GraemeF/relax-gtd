using System;
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
        private const string ApplicationPath = @"..\..\..\..\Relax\bin\" + Configuration + @"\Relax.exe";

        #endregion

        /// <summary>
        /// Launches an instance of Relax for testing.
        /// </summary>
        /// <returns>The launched instance.</returns>
        public static RelaxApplication Launch(bool newWorkspace, string workspacePath)
        {
            var args = new StringBuilder(" /nobugtrap");
            if (newWorkspace)
                args.Append(" /new");
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
                               Console.WriteLine("Looking for Relax . . . ");
                               shell = desktop.FindFirst(TreeScope.Children,
                                                         new PropertyCondition(
                                                             AutomationElement.NameProperty,
                                                             "Relax GTD"));

                               return shell != null;
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

        #region IDisposable Members

        public void Dispose()
        {
            _process.Dispose();
        }

        #endregion
    }
}