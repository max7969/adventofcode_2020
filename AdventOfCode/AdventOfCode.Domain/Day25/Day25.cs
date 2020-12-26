using AdventOfCode.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Domain.Day25
{
    public class Day25

    {
        public long Compute(string filePath)
        {
            var lines = FileReader.GetFileContent(filePath).ToList();
            var cardPublicKey = lines[0];
            var doorPublicKey = lines[1];

            long secretCardLoop = LoopUntil(cardPublicKey);
            long secretDoorLoop = LoopUntil(doorPublicKey);

            return GetPrivateKey(secretCardLoop, doorPublicKey);
        }

        public long LoopUntil(string key)
        {
            long target = long.Parse(key);
            long value = 1;
            long count = 0;
            while (value != target)
            {
                value = value * 7;
                value = value % 20201227;
                count++;
            }
            return count;
        }

        public long GetPrivateKey(long loop, string key)
        {
            long value = 1;
            long subjectNumber = long.Parse(key);
            for (var i = 0; i < loop; i++)
            {
                value = value * subjectNumber;
                value = value % 20201227;
            }
            return value;
        }
    }
}
