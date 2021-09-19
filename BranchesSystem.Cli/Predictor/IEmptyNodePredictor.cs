using BranchesSystem.Cli.Models;

namespace BranchesSystem.Cli.Predictor
{
    public interface IEmptyNodePredictor
    {
        void Execute(Node root);
    }
}