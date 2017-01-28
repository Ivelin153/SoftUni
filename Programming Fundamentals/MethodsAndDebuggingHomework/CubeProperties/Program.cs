using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeProperties
{
    public class Program
    {
        public static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            string toFind = Console.ReadLine();

            if (toFind == "face")
            {
                FindFaceDiagonals(side, toFind);
            }

            else if (toFind == "space")
            {
                FindSpaceDiagonals(side, toFind);
            }

            else if (toFind == "volume")
            {
                FindVolume(side, toFind);
            }

            else
            {
                FindArea(side, toFind);
            }
        }

        public static void FindFaceDiagonals(double side, string toFind)
        {
            var faceDiagonalLength = Math.Sqrt(2 * Math.Pow(side, 2));
            Console.WriteLine("{0:f2}", faceDiagonalLength);
        }

        public static void FindSpaceDiagonals(double side, string toFind)
        {
            var faceDiagonalLength = Math.Sqrt(3 * Math.Pow(side, 2));
            Console.WriteLine("{0:f2}", faceDiagonalLength);
        }

        public static void FindVolume(double side, string toFind)
        {
            var faceDiagonalLength = Math.Pow(side, 3);
            Console.WriteLine("{0:f2}", faceDiagonalLength);
        }

        public static void FindArea(double side, string toFind)
        {
            var faceDiagonalLength = 6 * Math.Pow(side, 2);
            Console.WriteLine("{0:f2}", faceDiagonalLength);
        }
    }
}
