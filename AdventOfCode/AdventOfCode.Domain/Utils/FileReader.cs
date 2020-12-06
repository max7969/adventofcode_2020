using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Domain.Utils
{
    public class FileReader
    {
        public static IEnumerable<string> GetFileContent(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
