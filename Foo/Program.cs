using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 3; i++)
            {
                var process = new Process
                {
                    StartInfo =
                    {
                        FileName = @"C:\study\NiquIoC\PerformanceCalculator\bin\Debug\PerformanceCalculator.exe",
                        RedirectStandardOutput = true,
                        UseShellExecute = false
                    }
                };

                process.Start();
                var standardOutput = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine(standardOutput);
            }
            Console.ReadLine();
        }
    }
}
