using System;
using System.Collections.Generic;
using System.Text;

namespace BranchesSystem.Cli.Output
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
        }
    }
}
