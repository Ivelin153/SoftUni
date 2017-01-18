using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            var workDaysInMonth = int.Parse(Console.ReadLine());
            var moneyPerDay = double.Parse(Console.ReadLine());
            var USDtoBGN = double.Parse(Console.ReadLine());

            var monthlyPayment = workDaysInMonth * moneyPerDay;
            var moneyForYear = monthlyPayment * 12 + monthlyPayment * 2.5;

            var Taxes = moneyForYear * 0.25;
            var afterTaxes = moneyForYear - Taxes;
            var toBGN = afterTaxes * USDtoBGN;
            var mpd = toBGN / 365;
            Console.WriteLine("{0:f2}", mpd);

        }
    }
}
