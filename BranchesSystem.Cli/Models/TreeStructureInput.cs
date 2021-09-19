using System;
using System.Collections.Generic;
using System.Text;

namespace BranchesSystem.Cli.Models
{
    public class TreeStructureInput
    {
        public TreeStructureInput(string depth)
        {
            Depth = depth;
        }
        public string Depth { get;  }
    }
}
