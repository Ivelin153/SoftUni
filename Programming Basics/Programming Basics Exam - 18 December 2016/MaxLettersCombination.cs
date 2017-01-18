using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLetter = char.Parse(Console.ReadLine());
            var lastLetter = char.Parse(Console.ReadLine());
            var skipLetter = char.Parse(Console.ReadLine());
            var counter = 0;
            for (char i = firstLetter; i <= lastLetter; i++)
            {
                if (i == skipLetter)
                {
                    continue;
                }
                for (char secondLetter = firstLetter; secondLetter <= lastLetter; secondLetter++)
                {
                    if (secondLetter == skipLetter)
                    {
                        continue;
                    }
                    for (char thirdLetter = firstLetter; thirdLetter <= lastLetter; thirdLetter++)
                    {
                        if (thirdLetter == skipLetter)
                        {
                            continue;
                        }
                        Console.Write("{0}{1}{2} ", i, secondLetter, thirdLetter);
                       
                        counter++;                        
                    }
                }
            }
            Console.Write(counter);
        }
    }
}
