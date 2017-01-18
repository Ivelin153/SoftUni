using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000daysAfterBirth
{
    class Program
    {
        static void Main(string[] args)
        {

            var dateOfBrith = Console.ReadLine();
            var format = "dd-MM-yyyy";                       
            var date = DateTime.ParseExact(dateOfBrith, format, null);
            var after1000Days = date.AddDays(999);
            Console.WriteLine("{0:dd-MM-yyyy}", after1000Days);


        }
    }
}
