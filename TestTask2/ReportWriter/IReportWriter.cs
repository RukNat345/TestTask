using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask2.FileParsers;

namespace TestTask2.ReportWriter
{
    public interface IReportWriter
    {
        /// <summary>
        /// Записать результат в файл
        /// </summary>
        public Task WriteAsync(ParseResult result);
    }
}
