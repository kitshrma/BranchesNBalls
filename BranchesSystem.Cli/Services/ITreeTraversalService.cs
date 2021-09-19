using BranchesSystem.Cli.Models;

namespace BranchesSystem.Cli.Services
{
    public interface ITreeTraversalService
    {
        void Traverse(Node root);
    }
}