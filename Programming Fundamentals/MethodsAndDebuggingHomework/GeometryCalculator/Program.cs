using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var figure = Console.ReadLine();

            if (figure == "triangle")
            {
                FindTriangleArea();
            }

            else if (figure == "square")
            {
                FindSquareArea();
            }

            else if (figure == "rectangle")
            {
                FindRectangleArea();
            }

            else
            {
                FindCircleArea();
            }
        }

        public static void FindTriangleArea()
        {
            var side = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area = side * height / 2;
            Console.WriteLine("{0:f2}", area);
        }

        public static void FindSquareArea()
        {
            var side = double.Parse(Console.ReadLine());
            var area = side * side;
            Console.WriteLine("{0:f2}", area);
        }

        public static void FindRectangleArea()
        {
            var width = double.Parse(Console.ReadLine());
            var length = double.Parse(Console.ReadLine());
            var area = width * length;
            Console.WriteLine("{0:f2}", area);
        }

        public static void FindCircleArea()
        {
            var radius = double.Parse(Console.ReadLine());
            var area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine("{0:f2}", area);
        }
    }
}
