using BranchesSystem.Cli.Models;

namespace BranchesSystem.Cli.PathTracer
{
    public interface IBallPathTracer
    {
        void Execute(Node root, TreeStructureInput treeStructureInput);
    }
}