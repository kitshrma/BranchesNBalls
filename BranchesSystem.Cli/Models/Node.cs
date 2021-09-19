using System;
using System.Collections.Generic;
using System.Text;

namespace BranchesSystem.Cli.Models
{
    public class Node
    {
        public Node(int val)
        {
            Value = val;
        }
        public int Value { get; }
        public bool Gate { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
