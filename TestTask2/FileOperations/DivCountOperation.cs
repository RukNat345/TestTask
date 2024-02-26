using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTask2.FileOperations
{
    public class DivCountOperation : IFileOperation
    {
        private readonly Regex template = new Regex(@"<\s*div[^>]*>(.*?)<\s*/\s*div>");
        public string OperationName => "посчитать количество тегов div";

        public string Calculate(string content)
        {
            return template.Matches(content).Count.ToString();
        }
    }
}
