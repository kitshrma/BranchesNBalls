using BranchesSystem.Cli.Models;
using BranchesSystem.Cli.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace BranchesSystem.Cli.Predictor
{
    public class EmptyNodePredictor : IEmptyNodePredictor
    {
        private readonly IConsoleWriter _consoleWriter;
        public EmptyNodePredictor(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }
        public void Execute(Node root)
        {
            if (root.Left == null && root.Right == null)
            {
                _consoleWriter.WriteLine($"Node {root.Value} will not receive the ball");
                return;
            }

            if (root.Gate)// take right node
                Execute(root.Right);
            else
                Execute(root.Left);
        }
    }
}
