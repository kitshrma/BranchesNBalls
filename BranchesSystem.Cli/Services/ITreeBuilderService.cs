using BranchesSystem.Cli.Models;

namespace BranchesSystem.Cli.Services
{
    public interface ITreeBuilderService
    {
        Node Build(TreeStructureInput treeStructureInput);
    }
}