using BranchesSystem.Cli.Models;
using BranchesSystem.Cli.Output;
using BranchesSystem.Cli.PathTracer;
using BranchesSystem.Cli.Predictor;
using BranchesSystem.Cli.Services;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BranchesSystem.Cli
{
    public class BranchesSystemApplication
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly ITreeBuilderService _treeBuilderService;
        private readonly ITreeTraversalService _treeTraversalService;
        private readonly IEmptyNodePredictor _emptyNodePredictor;
        private readonly IBallPathTracer _ballPathTracer;
        public BranchesSystemApplication(IConsoleWriter consoleWriter, ITreeBuilderService treeBuilderService, 
                                         ITreeTraversalService treeTraversalService, IEmptyNodePredictor emptyNodePredictor,
                                         IBallPathTracer ballPathTracer)
        {
            _consoleWriter = consoleWriter;
            _treeBuilderService = treeBuilderService;
            _treeTraversalService = treeTraversalService;
            _emptyNodePredictor = emptyNodePredictor;
            _ballPathTracer = ballPathTracer;
        }
        public async Task RunAsync(string[] args)
        {
            await Parser.Default
                .ParseArguments<BranchesSystemApplicationOption>(args)
                .WithParsedAsync( option => {

                    var treeStructureInput = new TreeStructureInput(option.Depth);
                    var root = _treeBuilderService.Build(treeStructureInput);
                    _treeTraversalService.Traverse(root);
                    _emptyNodePredictor.Execute(root);
                    _ballPathTracer.Execute(root, treeStructureInput);
                    return Task.CompletedTask;
                });

        }

        
    }
}
