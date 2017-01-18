using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAfter15min
{
    class Program
    {
        static void Main(string[] args)
        {
            var hour = int.Parse(Console.ReadLine());
            var min = int.Parse(Console.ReadLine());
            var after15min = min + 15;

            if (after15min <= 59)
            {
                Console.WriteLine("{0}:{1:00}",
                    hour,
                    after15min);
            }
            else if (after15min > 59)
            {
                if (hour == 23)
                {
                    hour -= 23;
                    var minutes = after15min - 60;
                    Console.WriteLine("{0}:{1:00}",
                        hour,
                        minutes);
                }
                else
                {
                    hour++;
                    var minutes = after15min - 60;
                    Console.WriteLine("{0}:{1:00}",
                        hour,
                        minutes);
                }
            }
        }
    }
}
