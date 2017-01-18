using System;


namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = int.Parse(Console.ReadLine());
            var n2 = int.Parse(Console.ReadLine());
            var operation = Console.ReadLine();

            if (operation == "+")
            {
                var sum = n1 + n2;
                Console.Write("{0} + {1} = {2}",
                    n1,
                    n2,
                    sum);
                if (sum % 2 == 0)
                {
                    Console.WriteLine(" - even");
                }
                else
                {
                    Console.WriteLine(" - odd");
                }
            }
            else if (operation == "-")
            {
                var difference = n1 - n2;
                Console.Write("{0} - {1} = {2}",
                    n1,
                    n2,
                    difference);
                if (difference % 2 == 0)
                {
                    Console.WriteLine(" - even");
                }
                else
                {
                    Console.WriteLine(" - odd");
                }
            }
            else if (operation == "*")
            {
                var multiplication = n1 * n2;
                Console.Write("{0} * {1} = {2}",
                   n1,
                   n2,
                   multiplication);
                if (multiplication % 2 == 0)
                {
                    Console.WriteLine(" - even");
                }
                else
                {
                    Console.WriteLine(" - odd");
                }
            }
            else if (operation == "/")
            {
                if (n2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
                else
                {
                    var division = (double)n1 / n2;
                    Console.WriteLine("{0} / {1} = {2:f2}",
                       n1,
                       n2,
                       division);
                }
            }

            else if (operation == "%")
            {
                if (n2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
                else
                {
                    var division = (double)n1 % n2;
                    Console.WriteLine("{0} % {1} = {2}",
                       n1,
                       n2,
                       division);
                }
            }


        }
    }
}
