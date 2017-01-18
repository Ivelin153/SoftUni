using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = int.Parse(Console.ReadLine());
            var n2 = int.Parse(Console.ReadLine());
            var Operators = char.Parse(Console.ReadLine());
            var result = 0.00;

            if (Operators == '+')
            {
                result = n1 + n2;
                Console.Write("{0} + {1} = {2} - ", n1, n2, result);
                if (result % 2 == 0)
                {
                    Console.WriteLine("even");
                }
                else
                {
                    Console.WriteLine("odd");
                }
            }
            else if (Operators == '-')
            {
                result = n1 - n2;
                Console.Write("{0} - {1} = {2} - ", n1, n2, result);
                if (result % 2 == 0)
                {
                    Console.WriteLine("even");
                }
                else
                {
                    Console.WriteLine("odd");
                }
            }
            else if (Operators == '*')
            {
                result = n1 * n2;
                Console.Write("{0} * {1} = {2} - ", n1, n2, result);
                if (result % 2 == 0)
                {
                    Console.WriteLine("even");
                }
                else
                {
                    Console.WriteLine("odd");
                }
            }
            else if (Operators == '/')
            {
                if (n2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
                else
                {
                    result = (double)n1 / n2;
                    Console.Write("{0} / {1} = {2:f2}", n1, n2, result);
                }

            }
            else if (Operators == '%')
            {
                
                if (n2 == 0)
                {
                    Console.WriteLine("Cannot divide {0} by zero", n1);
                }
            
                else
                {
                    result = n1 % n2;
                    Console.Write("{0} % {1} = {2}", n1, n2, result);
                }
            }
        }
    }
}
