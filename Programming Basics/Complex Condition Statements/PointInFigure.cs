using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInTheFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = int.Parse(Console.ReadLine());
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());

            var widthOfRectangle1 = 3 * h;
            var heightOfRectangle1 = h;

            if ((x < 0 || x > 3 * h || y < 0 || y > h) && (x < h || x > 2 * h || y < h || y > 4 * h))
            {

                Console.WriteLine("outside");
            }

            else if ((x > 0 && x < widthOfRectangle1 && y > 0 && y < h) || (x > h && x < 2 * h && y >= h && y < 4 * h))
            {
                Console.WriteLine("inside");
            }

            else
            {
                Console.WriteLine("border");
            }


        }
    }
}
