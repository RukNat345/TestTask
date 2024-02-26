using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2.FileOperations
{
    /// <inheritdoc cref="IFileOperation"/>
    public class PunctuationMarksCountFileOperation : IFileOperation
    {
        public string OperationName => "подсчитать количество знаков препинания";

        public string Calculate(string content)
        {
            return $"{content.Count(Char.IsPunctuation)}";
        }
    }
}
