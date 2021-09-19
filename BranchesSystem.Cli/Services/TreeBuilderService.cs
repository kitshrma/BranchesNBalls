using System;
using System.Collections.Generic;
using System.Text;
using BranchesSystem.Cli.Models;
using BranchesSystem.Cli.Output;

namespace BranchesSystem.Cli.Services
{
    public class TreeBuilderService : ITreeBuilderService
    {
        private readonly IConsoleWriter _consoleWriter;
        public TreeBuilderService(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }
        public Node Build(TreeStructureInput treeStructureInput)
        {
            //ToDo : Validate user input
            int depth = int.Parse(treeStructureInput.Depth);
            //Number of nodes in perfect binary tree
            int nodes = (int)Math.Pow(2, (depth + 1)) - 1;
            _consoleWriter.WriteLine($"Building tree structure for Depth {treeStructureInput.Depth} containing {nodes} nodes");
            //initiate an array to hold data for tree nodes where node value = index
            int[] data = new int[nodes];
            return CreateNode(data,0);
        }

        private Node CreateNode(int [] data,int i)
        {
            if (i >= data.Length)
                return null;
            Node next = new Node(i);
            next.Gate = (new Random().Next(2)) == 1;
            // Left child is on array index 2*i + 1 and right on 2*i + 2 
            next.Left = CreateNode(data, 2 * i + 1);
            next.Right = CreateNode(data, 2 * i + 2);
            return next;
        }
    }
}
