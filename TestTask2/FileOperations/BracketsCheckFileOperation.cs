using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask2.FileOperations
{
    public class BracketsCheckFileOperation : IFileOperation
    {
        public string OperationName => "сравнить количество открывающих и закрывающих скобок";

        public string Calculate(string content)
        {
            var openedBracketsCount = content.Count(x => x.Equals('{'));

            var closeddBracketsCount = content.Count(x => x.Equals('{'));

            return openedBracketsCount == closeddBracketsCount ? "совпадает" : "не совпадает";
        }
    }
}
