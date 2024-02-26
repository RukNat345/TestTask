using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2.FileOperations
{
    public interface IFileOperation
    {
        /// <summary>
        /// Название операции над файлом
        /// </summary>
        public string OperationName { get; }

        /// <summary>
        /// Произвести операции над файлом
        /// </summary>
        public string Calculate(string content);
    }
}
