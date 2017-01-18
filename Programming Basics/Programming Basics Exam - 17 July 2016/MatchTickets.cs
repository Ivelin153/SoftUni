using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var ticket = Console.ReadLine();
            var numberOfPeople = int.Parse(Console.ReadLine());
            var transportPrice = 0.00;
            var normal = 249.99;
            var vip = 499.99;
            var allTicketPrice = 0.00;

            if (numberOfPeople <= 4)
            {
                transportPrice = budget * 0.75;

            }
            else if (numberOfPeople <= 9)
            {
                transportPrice = budget * 0.60;
            }
            else if (numberOfPeople <= 24)
            {
                transportPrice = budget * 0.5;
            }
            else if (numberOfPeople <= 49)
            {
                transportPrice = budget * 0.40;
            }
            else
            {
                transportPrice = budget * 0.25;
            }
            var moneyLeft = budget - transportPrice;

            if (ticket == "Normal")
            {
                allTicketPrice = numberOfPeople * normal;
                if (allTicketPrice > moneyLeft)
                {
                    Console.WriteLine("Not enough money! You need {0:f2} leva.", Math.Abs(allTicketPrice - moneyLeft));
                }
                else
                {
                    Console.WriteLine("Yes! You have {0:f2} leva left.", moneyLeft - allTicketPrice);
                }
            }
            else
            {
                allTicketPrice = numberOfPeople * vip;
                if (allTicketPrice > moneyLeft)
                {
                    Console.WriteLine("Not enough money! You need {0:f2} leva.", Math.Abs(allTicketPrice - moneyLeft));
                }
                else
                {
                    Console.WriteLine("Yes! You have {0:f2} leva left.", moneyLeft - allTicketPrice);
                }
            }
        }
    }
}
