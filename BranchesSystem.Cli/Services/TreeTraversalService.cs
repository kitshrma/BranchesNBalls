using BranchesSystem.Cli.Models;
using BranchesSystem.Cli.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace BranchesSystem.Cli.Services
{
    public class TreeTraversalService : ITreeTraversalService
    {
        private readonly IConsoleWriter _consoleWriter;
        public TreeTraversalService(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }
        public void Traverse(Node root)
        {
            _consoleWriter.WriteLine($"Breadth First Traversal of tree structure (* means Gate = LEFT) :");
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                Node current = q.Dequeue();
                if (current == null)
                    continue;

                string nodeName = current.Value.ToString();
                if (current.Gate)
                    nodeName += "*";
                _consoleWriter.WriteLine(nodeName);
                q.Enqueue(current.Left);
                q.Enqueue(current.Right);
            }
        }
    }
}
