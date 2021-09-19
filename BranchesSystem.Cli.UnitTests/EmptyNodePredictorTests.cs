using BranchesSystem.Cli.Models;
using BranchesSystem.Cli.Output;
using BranchesSystem.Cli.Predictor;
using NSubstitute;
using System;
using Xunit;

namespace BranchesSystem.Cli.UnitTests
{
    public class EmptyNodePredictorTests
    {
        private readonly EmptyNodePredictor _sut;
        private readonly IConsoleWriter _consoleWriter = Substitute.For<IConsoleWriter>();

        public EmptyNodePredictorTests()
        {
            _sut = new EmptyNodePredictor(_consoleWriter);
        }

        [Fact]
        public void PredictorExecute_ShouldPredictEmptyNode()
        {
            //Arange
            const string expectedConsoleOutput = "Node 2 will not receive the ball";
            Node root = GenerateTestTree();

            //Act
            _sut.Execute(root);

            //Assert
            _consoleWriter.Received(1).WriteLine(Arg.Is(expectedConsoleOutput));
        }

        private Node GenerateTestTree()
        {
            // Base case for prediction : tree with depth = 1
            // For root node gate is switched to left
            // One ball will go to Node 1
            //    0*
            // 1     2 
            Node root = new Node(0);
            root.Gate = true;

            Node leftChild = new Node(1);
            leftChild.Gate = false;

            Node rightChild = new Node(2);
            rightChild.Gate = true;

            root.Left = leftChild;
            root.Right = rightChild;

            return root;
        }
    }
}
