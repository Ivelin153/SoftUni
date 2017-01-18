using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfAdults = int.Parse(Console.ReadLine());
            var numberOfStudents = int.Parse(Console.ReadLine());
            var numberOfNights = int.Parse(Console.ReadLine());
            var typeOfTransport = Console.ReadLine();
            var transportPrice = 0.00;
            var hotelPrice = 0.00; ;
            var commision = 0.00;
            var total = 0.00;

            var adultsPrice = 0.00;
            var studnetsPrice = 0.00;

            if (typeOfTransport == "airplane")
            {
                adultsPrice = 70.00;
                studnetsPrice = 50.00;
                transportPrice = ((numberOfAdults * adultsPrice) + (numberOfStudents * studnetsPrice)) * 2;
                hotelPrice = numberOfNights * 82.99;
                commision = (transportPrice + hotelPrice) * 0.1;
                total = transportPrice + hotelPrice + commision;
                Console.WriteLine("{0:f2}", total);
            }
            else if (typeOfTransport == "train")
            {
                if (numberOfAdults + numberOfStudents >= 50)
                {
                    adultsPrice = 24.99 * 0.5;
                    studnetsPrice = 14.99 * 0.5;
                    transportPrice = ((numberOfAdults * adultsPrice) + (numberOfStudents * studnetsPrice)) * 2;
                    hotelPrice = numberOfNights * 82.99;
                    commision = (transportPrice + hotelPrice) * 0.1;
                    total = transportPrice + hotelPrice + commision;
                    Console.WriteLine("{0:f2}", total);
                }
                else
                {
                    adultsPrice = 24.99;
                    studnetsPrice = 14.99;
                    transportPrice = ((numberOfAdults * adultsPrice) + (numberOfStudents * studnetsPrice)) * 2;
                    hotelPrice = numberOfNights * 82.99;
                    commision = (transportPrice + hotelPrice) * 0.1;
                    total = transportPrice + hotelPrice + commision;
                    Console.WriteLine("{0:f2}", total);
                }

            }
            else if (typeOfTransport == "bus")
            {
                adultsPrice = 32.50;
                studnetsPrice = 28.50;
                transportPrice = ((numberOfAdults * adultsPrice) + (numberOfStudents * studnetsPrice)) * 2;
                hotelPrice = numberOfNights * 82.99;
                commision = (transportPrice + hotelPrice) * 0.1;
                total = transportPrice + hotelPrice + commision;
                Console.WriteLine("{0:f2}", total);
            }
            else
            {
                adultsPrice = 42.99;
                studnetsPrice = 39.99;
                transportPrice = ((numberOfAdults * adultsPrice) + (numberOfStudents * studnetsPrice)) * 2;
                hotelPrice = numberOfNights * 82.99;
                commision = (transportPrice + hotelPrice) * 0.1;
                total = transportPrice + hotelPrice + commision;
                Console.WriteLine("{0:f2}", total);
            }
        }
    }
}
