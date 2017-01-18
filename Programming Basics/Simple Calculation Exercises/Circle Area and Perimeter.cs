using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = double.Parse(Console.ReadLine());
            var area = Math.PI * Math.Pow(r, 2);
            var perimeter = 2 * Math.PI * r;
            Console.WriteLine(area);
            Console.WriteLine(perimeter);



        }
    }
}
