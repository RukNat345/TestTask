using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask2.FileOperations;

namespace TestTask2.FileParsers
{
    /// <inheritdoc cref="IFileParser"/>
    public class CssParser : DefaultParser
    {
        public override string GetExtension()
        {
            return ".css";
        }
    }
}
