using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var sum = 0;

            for (int i = 0; i <= str.Length - 1; i++)
            {
                if (str[i] == 'a')
                {
                    sum += 1;
                }
                else if (str[i] == 'e')
                {
                    sum += 2;
                }
                else if (str[i] == 'i')
                {
                    sum += 3;
                }
                else if (str[i] == 'o')
                {
                    sum += 4;
                }
                else if (str[i] == 'u')
                {
                    sum += 5;
                }
               
            }
            Console.WriteLine(sum);
        }
    }
}
