using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask2.FileOperations;
using TestTask2.FileParsers;
using TestTask2.ReportWriter;

namespace TestTask2.Watcher
{
    /// <summary>
    /// Наблюдение за папкой на предмет появления новых файлов
    /// </summary>
    public class DirectoryWatcher
    {
        private FileSystemWatcher _watcher;

        private string _sourceDirectory;

        private readonly IFileParser[] _parsers;

        private IReportWriter _reportWriter;

        public DirectoryWatcher(IFileParser[] parsers, IReportWriter reportWriter)
        {
            _parsers = parsers;
            _reportWriter = reportWriter;

            _sourceDirectory = ConfigurationManager.AppSettings["SourceDirectory"];

            if (string.IsNullOrWhiteSpace(_sourceDirectory))
            {
                throw new ArgumentException("Не указана SourceDirectory");
            }

            _watcher = new FileSystemWatcher(_sourceDirectory)
            {
                NotifyFilter = NotifyFilters.FileName,
                EnableRaisingEvents = true,
            };

            _watcher.Created += OnFileCreated;
        }

        /// <summary>
        /// Появление нового файла
        /// </summary>
        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {
            var extension = Path.GetExtension(e.FullPath);

            IFileParser parser;

            switch(extension)
            {
                case ".css":

                    parser = _parsers.FirstOrDefault(x => x.GetExtension() != null && x.GetExtension().Equals(".css"));

                    if (parser != null)
                    {
                        parser.AddOperation(new BracketsCheckFileOperation());
                    }

                    break;

                case ".html":

                    parser = _parsers.FirstOrDefault(x => x.GetExtension() != null && x.GetExtension().Equals(".html"));

                    if (parser != null)
                    {
                        parser.AddOperation(new DivCountOperation());
                    }

                    break;

                default:

                    parser = _parsers.FirstOrDefault(x => x.GetExtension() == null);

                    if (parser != null)
                    {
                        parser.AddOperation(new PunctuationMarksCountFileOperation());
                    }

                    break;
            }

            var results = parser?.ParseAsync(e.FullPath).Result;

            foreach(var result in results)
            {
                _reportWriter.WriteAsync(result);
            }
        }
    }
}
