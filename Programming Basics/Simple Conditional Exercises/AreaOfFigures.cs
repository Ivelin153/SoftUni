using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();
            var area = 0.00;
            if (figure == "square")
            {
                var a = double.Parse(Console.ReadLine());
                area = a * a;
                Console.WriteLine(area);
            }
            else if (figure == "rectangle")
            {
                var a = double.Parse(Console.ReadLine());
                var b = double.Parse(Console.ReadLine());
                area = a * b;
                Console.WriteLine(area);
            }
            else if (figure == "circle")
            {
                var r = double.Parse(Console.ReadLine());
                area = Math.PI * r * r;
                Console.WriteLine(area);
            }
            else if (figure == "triangle")
            {
                var a = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());
                area = a * h / 2;
                Console.WriteLine(area);
            }
        }
    }
}
