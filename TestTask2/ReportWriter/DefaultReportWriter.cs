using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask2.FileParsers;

namespace TestTask2.ReportWriter
{
    public class DefaultReportWriter : IReportWriter
    {
        private string _resultDirectory;

        public DefaultReportWriter()
        {
            _resultDirectory = ConfigurationManager.AppSettings["ResultDirectory"];

            if (string.IsNullOrWhiteSpace(_resultDirectory))
            {
                throw new ArgumentException("Не указана ResultDirectory");
            }
        }

        public async Task WriteAsync(ParseResult result)
        {
            try
            {
                lock (this)
                {
                    File.AppendAllText(_resultDirectory, result.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message));
            }
        }
    }
}
