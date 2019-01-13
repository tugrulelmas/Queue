using Abioka.Queue.Common;
using Abioka.Queue.Receiver.Abstractions;
using Abioka.Queue.Receiver.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Abioka.Queue.Receiver
{
    internal class Program
    {
        private static void Main(string[] args) {
            var serviceProvider = RegisterServices(args);

            var startup = serviceProvider.GetService<IStartup>();
            startup.Start();
        }

        private static ServiceProvider RegisterServices(string[] args) {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            IServiceCollection services = new ServiceCollection();

            return services
                .AddOptions()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<ISender, Sender>()
                .AddSingleton<IExceptionSender, ExceptionSender>()
                .AddSingleton<IDuplicateSender, DuplicateSender>()
                .AddSingleton<IRepeater, Repeater>()
                .AddSingleton<IUserConverter, UserConverter>()
                .AddSingleton<IConsumer, StatusConsumerRepeater>(x => new StatusConsumerRepeater(new StatusConsumerDuplicateChecker(new StatusConsumer(), x.GetService<IDuplicateSender>()), x.GetService<IRepeater>()))
                .AddSingleton<IQueueConsumer, StatusQueueConsumer>()
                .AddSingleton<IStartup, Startup>()
                .BuildServiceProvider();
        }
    }
}