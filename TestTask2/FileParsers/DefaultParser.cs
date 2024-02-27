using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask2.FileOperations;

namespace TestTask2.FileParsers
{
    /// <inheritdoc cref="IFileParser"/>
    public class DefaultParser : IFileParser
    {
        public virtual string GetExtension()
        {
            return null;
        }

        protected List<IFileOperation> _fileOperations;

        public DefaultParser()
        {
            _fileOperations = new List<IFileOperation>();
        }

        public async Task<List<ParseResult>> ParseAsync(string filePath)
        {
            string content;

            try
            {
                content = await File.ReadAllTextAsync(filePath);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return null;
            }

            var result = new List<ParseResult>();

            foreach(var operation in _fileOperations)
            {
                var calculationResult = operation.Calculate(content);
                result.Add(
                    new ParseResult
                    {
                        OperationName = operation.OperationName,
                        FileName = Path.GetFileNameWithoutExtension(filePath),
                        Result = calculationResult
                    });
            }

            return result;
        }

        public void AddOperation(IFileOperation fileOperation)
        {
            _fileOperations.Add(fileOperation);
        }
    }
}
