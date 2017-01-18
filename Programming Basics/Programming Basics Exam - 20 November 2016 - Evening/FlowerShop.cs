using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfMagnolias = int.Parse(Console.ReadLine());
            var numberOfHyacinth = int.Parse(Console.ReadLine());
            var numberOfRoses = int.Parse(Console.ReadLine());
            var numberOfCactus = int.Parse(Console.ReadLine());
            var giftPrice = double.Parse(Console.ReadLine());

            var totalPrice = ((numberOfMagnolias * 3.25) + (numberOfHyacinth * 4) + (numberOfRoses * 3.5) + (numberOfCactus * 8));
            var afterTaxes = totalPrice - totalPrice * 0.05;

            if (giftPrice <= afterTaxes)
            {
                Console.WriteLine("She is left with {0} leva.", Math.Floor(afterTaxes - giftPrice));
            }
            else
            {
                Console.WriteLine("She will have to borrow {0} leva.", Math.Ceiling(giftPrice - afterTaxes));
            }

        }
    }
}
