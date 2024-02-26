using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2.FileParsers
{
    /// <summary>
    /// Результат обработки файла
    /// </summary>
    public class ParseResult
    {
        /// <summary>
        /// Название файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Название операции над файлом
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Результат подсчета
        /// </summary>
        public string Result { get; set; }

        public override string ToString()
        {
            return FileName + "-" + OperationName + "-" + Result + "\n";
        }
    }
}
