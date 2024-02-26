using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask2.FileOperations;
using TestTask2.FileParsers;

namespace TestTask2.FileParsers
{
    public interface IFileParser
    {
        /// <summary>
        /// Получить тип файла (расширение)
        /// </summary>
        public string GetExtension();

        /// <summary>
        /// Обработать файл
        /// </summary>
        public Task<List<ParseResult>> ParseAsync(string filePath);

        /// <summary>
        /// Добавить операцию над файлом
        /// </summary>
        public void AddOperation(IFileOperation fileOperation);
    }
}
