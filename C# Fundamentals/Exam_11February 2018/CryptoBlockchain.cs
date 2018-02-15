namespace CryptoBlockchain
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class CryptoBlockchain
    {
        public static void Main()
        {
            var regex = new Regex(@"({(([\D]+)?)(\d+)([\D]+)?})|(\[(([\D]+)?)(\d+)([\D]+)?])");

            var numberOfRows = int.Parse(Console.ReadLine());
            var onOneLine = string.Empty;

            for (int i = 0; i < numberOfRows; i++)
            {
                onOneLine += Console.ReadLine();
            }

            var matches = regex.Matches(onOneLine);
            var result = new List<int>();

            var currentBlockLength = 0;
            var currentText = string.Empty;

            foreach (Match match in matches)
            {
                var stringMatch = match.ToString();
                currentBlockLength = stringMatch.Length;
                if (stringMatch[0] == '[' && stringMatch[currentBlockLength - 1] == ']')
                {
                    if (match.Groups[9].Value.Length % 3 == 0)
                    {
                        currentText = match.Groups[9].Value;
                        NumbersToText(currentText, currentBlockLength, result);
                    }
                    else
                        continue;
                }
                else if (stringMatch[0] == '{' && stringMatch[currentBlockLength - 1] == '}')
                {
                    if (match.Groups[4].Value.Length % 3 == 0)
                    {
                        currentText = match.Groups[4].Value;
                        NumbersToText(currentText, currentBlockLength, result);
                    }
                    else
                        continue;
                }
                else
                    continue;
            }
            foreach (var symbol in result)
            {
                Console.Write((char)symbol);
            }
        }

        public static void NumbersToText(string text, int currentLength, List<int> result)
        {
            var substrings = string.Empty;

            for (int i = 0; i < text.Length; i += 3)
            {
                substrings = text.Substring(i, 3);
                var currentChar = int.Parse(substrings) - currentLength;
                result.Add(currentChar);
            }
        }
    }
}
