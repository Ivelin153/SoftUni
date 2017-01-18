using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = Console.ReadLine();
            var numberOfHolidays = int.Parse(Console.ReadLine());
            var toHomeTown = int.Parse(Console.ReadLine());
            var weekendsInYear = 48;
            var gamesInSofia = ((weekendsInYear - toHomeTown) * 3.00) / 4;
            var gamesOnHolidays = (numberOfHolidays * 2) / 3.00;
            var totalGamesPerYear = gamesInSofia + gamesOnHolidays + toHomeTown;
            
            if (year == "leap")
            {
                totalGamesPerYear *= 1.15;
                Console.WriteLine(Math.Floor(totalGamesPerYear));
            }
            else
            {
                Console.WriteLine(Math.Floor(totalGamesPerYear));
            }
        }
    }
}
