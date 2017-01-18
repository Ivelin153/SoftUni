using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var rad = double.Parse(Console.ReadLine());
            var degrees = (180 * rad) / Math.PI;
            Console.WriteLine(Math.Round(degrees, 2));
        }
    }
}
