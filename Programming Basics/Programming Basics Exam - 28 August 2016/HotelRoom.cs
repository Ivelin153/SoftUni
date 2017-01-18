using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine();
            var days = int.Parse(Console.ReadLine());
            var apartamentPrice = 0.00;
            var studioPrice = 0.00;

            if (month == "May" || month == "October")
            {
                apartamentPrice = 65.00;
                studioPrice = 50.00;
                if (days <= 7)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", apartamentPrice * days);
                    Console.WriteLine("Studio: {0:f2} lv.", studioPrice * days);
                }
                else if (days > 7 && days <= 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.05);
                    Console.WriteLine("Apartment: {0:f2} lv.", apartamentPrice * days);
                    Console.WriteLine("Studio: {0:f2} lv.", studioPrice * days);
                }
                else if (days > 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.3);
                    apartamentPrice = apartamentPrice - (apartamentPrice * 0.1);
                    Console.WriteLine("Apartment: {0:f2} lv.", apartamentPrice * days);
                    Console.WriteLine("Studio: {0:f2} lv.", studioPrice * days);
                }
            }

            else if (month == "June" || month == "September")
            {
                apartamentPrice = 68.70;
                studioPrice = 75.20;
                if (days <= 14)
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", apartamentPrice * days);
                    Console.WriteLine("Studio: {0:f2} lv.", studioPrice * days);
                }
                else
                {
                    studioPrice = studioPrice - (studioPrice * 0.2);
                    apartamentPrice = apartamentPrice - (apartamentPrice * 0.1);
                    Console.WriteLine("Apartment: {0:f2} lv.", apartamentPrice * days);
                    Console.WriteLine("Studio: {0:f2} lv.", studioPrice * days);
                }
            }
            else
            {
                apartamentPrice = 77.00;
                studioPrice = 76.00;

                if (days > 14)
                {
                    apartamentPrice = apartamentPrice - (apartamentPrice * 0.1);
                    Console.WriteLine("Apartment: {0:f2} lv.", apartamentPrice * days);
                    Console.WriteLine("Studio: {0:f2} lv.", studioPrice * days);
                }
                else
                {
                    Console.WriteLine("Apartment: {0:f2} lv.", apartamentPrice * days);
                    Console.WriteLine("Studio: {0:f2} lv.", studioPrice * days);
                }
            }
        }
    }
}
