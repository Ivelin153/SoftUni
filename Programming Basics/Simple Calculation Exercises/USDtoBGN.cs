using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            var usd = double.Parse(Console.ReadLine());
            var bgn =Math.Round(usd * 1.79549,2);
            Console.WriteLine(bgn);
        }
    }
}
