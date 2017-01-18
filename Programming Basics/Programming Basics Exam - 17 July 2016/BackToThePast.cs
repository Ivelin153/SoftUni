using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            var heritage = double.Parse(Console.ReadLine());
            var yearToLive = int.Parse(Console.ReadLine());
            var moneyForEvenYear = 0.00;
            var moneyForOddYear = 0.00;

            for (int y = 1800; y <= yearToLive; y++)
            {
                if (y % 2 == 0)
                {
                    moneyForEvenYear += 12000;
                }
                else
                {
                    moneyForOddYear += 12000 + 50 * (y - 1800 + 18);
                }
            }
            var totalMoneySpent = moneyForEvenYear + moneyForOddYear;
            var moneyLeft = Math.Abs(heritage - totalMoneySpent);

            if (heritage >= totalMoneySpent)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:f2} dollars left.",
                    moneyLeft);
            }
            else
            {
                Console.WriteLine("He will need {0:f2} dollars to survive.",
                    moneyLeft);
            }
        }
    }
}
