using BranchesSystem.Cli.Output;
using BranchesSystem.Cli.PathTracer;
using BranchesSystem.Cli.Predictor;
using BranchesSystem.Cli.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BranchesSystem.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                ServiceProvider serviceProvider = BuildServiceProvider();

                var app = serviceProvider.GetRequiredService<BranchesSystemApplication>();

                await app.RunAsync(args);
            }
            catch(Exception ex)
            {
                //ToDo : Log exceptions
                throw ex;
            }
            

        }

        private static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<BranchesSystemApplication>();
            services.AddSingleton<IConsoleWriter, ConsoleWriter>();
            services.AddSingleton<ITreeBuilderService, TreeBuilderService>();
            services.AddSingleton<ITreeTraversalService, TreeTraversalService>();
            services.AddSingleton<IEmptyNodePredictor, EmptyNodePredictor>();
            services.AddSingleton<IBallPathTracer, BallPathTracer>();
        }
    }
}
