using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitcoin = int.Parse(Console.ReadLine());
            var chaineseYuan = double.Parse(Console.ReadLine());
            var comission = double.Parse(Console.ReadLine());

            var money = (bitcoin * 1168 + (chaineseYuan * 0.15) * 1.76) / 1.95;
            var afterComission = money * (comission / 100);
            var moneyInEUR = money - afterComission;
            Console.WriteLine(moneyInEUR);
        }
    }
}
