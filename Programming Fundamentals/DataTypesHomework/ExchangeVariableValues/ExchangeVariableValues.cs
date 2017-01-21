 using System;
namespace ExchangeVariableValues
{
    class ExchangeVariableValues
    {
        static void Main(string[] args)
        {
            var a = 5;
            var b = 10;
            Console.WriteLine($@"Before:
a = {a}
b = {b}");
            var y = b;
            b = a;
            a = y;
            Console.WriteLine($@"After:
a = {a}
b = {b}");

        }
    }
}
