using BranchesSystem.Cli.Models;
using BranchesSystem.Cli.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace BranchesSystem.Cli.PathTracer
{
    public class BallPathTracer : IBallPathTracer
    {
        private readonly IConsoleWriter _consoleWriter;
        public BallPathTracer(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void Execute(Node root, TreeStructureInput treeStructureInput)
        {
            int depth = int.Parse(treeStructureInput.Depth);
            int leafNodesCount = (int)Math.Pow(2, depth);

            //balls passed = leaf nodes -1
            for (int i = 1; i < leafNodesCount; i++)
            {
                string path = TracePath(root);
                _consoleWriter.WriteLine($"Ball {i} will run through following nodes {path}");
            }

        }

        private string TracePath(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            List<string> Path = new List<string>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                Node current = q.Dequeue();

                if (current == null)
                    continue;
                Path.Add(current.Value.ToString());
                if (current.Gate)
                    q.Enqueue(current.Left);
                else
                    q.Enqueue(current.Right);

                current.Gate = !current.Gate;
            }

            return string.Join(" --> ", Path);
        }
    }
}
