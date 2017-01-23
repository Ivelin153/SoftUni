using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelOrDigit
{
    class VowelOrDigit
    {
        static void Main(string[] args)
        {
            var input = char.Parse(Console.ReadLine());

            if (input == 'a' || input == 'e' || input == 'o' || input == 'u' || input == 'i')
            {
                Console.WriteLine("vowel");
            }
            else if (input >= 48 && input <= 57)
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
