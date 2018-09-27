using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace qaTechTests.Helpers
{
    public class AppHelper
    {
        private static Process cmd;

        public void StartReactApp()
        {
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var path = currentPath;

            //Get the path where to start the app from
            do
            {
                path = Path.GetFullPath(Path.Combine(path, @"..\"));
            } while (!Directory.GetFiles(path).Any(x => x.Contains("README.md")));

            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.WorkingDirectory = path;
            cmdsi.Arguments = "/K" + "yarn start";
            cmdsi.RedirectStandardOutput = true;
            cmdsi.RedirectStandardInput = true;
            cmdsi.UseShellExecute = false;
            cmd = Process.Start(cmdsi);

            //So wait until output says the following, I am sure there is a better way to do this.
            var output = "";
            do
            {
                output = cmd.StandardOutput.ReadLine();
            } while (!(output.Contains("You can now view") || output.Contains("Done")));
        }

        public void EndApp()
        {
            var processes = Process.GetProcesses();
            //node seems to hog the port if not closed.

            foreach (var process in Process.GetProcessesByName("node"))
            {
                if (!process.HasExited)
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
        }
    }
}