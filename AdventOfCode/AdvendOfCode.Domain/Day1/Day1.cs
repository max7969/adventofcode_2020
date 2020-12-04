using System.IO;
using System.Linq;
using AdventOfCode.Domain.Utils;

namespace AdventOfCode.Domain.Day1
{
    public class Day1
    {
        public int Compute(string filePath, int entriesCount)
        {
            var elements = FileReader.GetFileContent(filePath).Select(x => int.Parse(x));

            foreach (var element in elements)
            {
                foreach (var secondElement in elements)
                {
                    if (entriesCount == 2 && element + secondElement == 2020)
                    {
                        return element * secondElement;
                    }
                    else
                    {
                        foreach (var thirdElement in elements)
                        {
                            if (element + secondElement + thirdElement == 2020)
                            {
                                return element * secondElement * thirdElement;
                            }
                        }
                    }
                }
            }

            return 0;
        }
    }
}
