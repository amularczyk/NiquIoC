using System.Diagnostics;

namespace Foo
{
    public static class ProcessHelper
    {
        public static string StartProcess(string fileName, string arguments)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = fileName,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };

            process.Start();
            var standardOutput = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return standardOutput;
        }
    }
}