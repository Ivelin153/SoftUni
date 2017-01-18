using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var word1 = Console.ReadLine();
            var word2 = Console.ReadLine();
            var word1Lower = word1.ToLower();
            var word2Lower = word2.ToLower();

            if (word1Lower == word2Lower)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
