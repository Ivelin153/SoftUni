using System;


namespace TradeComission
{
    class Program
    {
        static void Main(string[] args)
        {
            var city = Console.ReadLine().ToLower();
            var sales = double.Parse(Console.ReadLine());
            var comission = 0.00;
            var salesComission = 0.00;

            if (city == "sofia")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales <= 500)
                {
                    comission = 0.05;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else if (sales <= 1000)
                {
                    comission = 0.07;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else if (sales <= 10000)
                {
                    comission = 0.08;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else
                {
                    comission = 0.12;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
            }

            else if (city == "varna")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales <= 500)
                {
                    comission = 0.045;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else if (sales <= 1000)
                {
                    comission = 0.075;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else if (sales <= 10000)
                {
                    comission = 0.10;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else
                {
                    comission = 0.13;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
            }
            else if (city == "plovdiv")
            {
                if (sales < 0)
                {
                    Console.WriteLine("error");
                }
                else if (sales <= 500)
                {
                    comission = 0.055;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else if (sales <= 1000)
                {
                    comission = 0.08;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else if (sales <= 10000)
                {
                    comission = 0.12;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
                else
                {
                    comission = 0.145;
                    salesComission = sales * comission;
                    Console.WriteLine(salesComission);
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
