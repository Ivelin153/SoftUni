using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StringAndObjects
{
    class StringAndObjects
    {
        static void Main(string[] args)
        {
            string firstString = "Hello ";
            string secondString = "World";
            object concatenate = firstString + secondString;
            string afterConcatination = (String)concatenate;
            Console.WriteLine(afterConcatination);
        }
    }
}
