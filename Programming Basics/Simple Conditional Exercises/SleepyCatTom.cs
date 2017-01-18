using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyCatTom
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysOff = int.Parse(Console.ReadLine());
            var TomsNorm = 30000;
            var workingDays = 365 - daysOff;
            var playTime = workingDays * 63 + daysOff * 127;
            var difference = Math.Abs(TomsNorm - playTime);

            if (playTime > TomsNorm)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play",
                    difference / 60,
                    difference % 60);
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play",
                    difference / 60,
                    difference % 60);
            }
        }
    }
}
