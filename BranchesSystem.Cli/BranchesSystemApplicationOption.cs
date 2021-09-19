using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace BranchesSystem.Cli
{
    public class BranchesSystemApplicationOption
    {
        [Option('d',"depth",Required = true, HelpText = "Provide depth of tree structure to be created")]
        public string Depth { get; set; }
    }
}
