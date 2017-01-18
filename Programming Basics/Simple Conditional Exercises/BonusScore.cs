using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            var score = int.Parse(Console.ReadLine());
            var bonus = 0.00;

            if (score <= 100)
            {
                bonus += 5;
            }
            else if (score > 100 && score < 1000)
            {
                bonus = score * 0.2;
            }
            else if (score >= 1000)
            {
                bonus = score * 0.1;
            }

            if (score % 2 == 0)
            {
                bonus += 1;

            }
            else if (score % 10 == 5)
            {
                bonus += 2;
            }
            Console.WriteLine(bonus);
            Console.WriteLine(score + bonus);

        }
    }
}
