using System;

namespace CleverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            var lillyAge = int.Parse(Console.ReadLine());
            var washmachinePrice = double.Parse(Console.ReadLine());
            var toysPrice = int.Parse(Console.ReadLine());
            var toys = 0;
            var moneyPerBd = 0;
            var totalMoneyFromBD = 0;
            var totalMoney = 0;

            for (int i = 1; i <= lillyAge; i++)
            {
                if (i % 2 == 0)
                {
                    moneyPerBd += 10;
                    totalMoneyFromBD += moneyPerBd - 1;
                }
                else
                {
                    toys++;
                }
            }
            totalMoney = totalMoneyFromBD + toys * toysPrice;
            if (washmachinePrice <= totalMoney)
            {
                Console.WriteLine("Yes! {0:f2}", totalMoney - washmachinePrice);
            }
            else
            {
                Console.WriteLine("No! {0:f2}", washmachinePrice - totalMoney);
            }


        }
    }
}
