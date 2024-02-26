using System;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using TestTask2.FileParsers;
using TestTask2.ReportWriter;
using TestTask2.Watcher;

namespace TestTask2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var provider = ConfigureServices();
            var parsers = provider.GetServices<IFileParser>().ToArray();
            var reportWriter = provider.GetService<IReportWriter>();
            var watcher = new DirectoryWatcher(parsers, reportWriter);

            Console.WriteLine($"Watching started");
            Console.Write("Press any key to exit...");
            
            Console.ReadKey();
        }

        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton<IFileParser, CssParser>()
                .AddSingleton<IFileParser, HtmlParser>()
                .AddSingleton<IFileParser, DefaultParser>()
                .AddSingleton<IReportWriter, DefaultReportWriter>();

            return services.BuildServiceProvider();
        }
    }
}