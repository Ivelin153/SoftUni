using System;


namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var row = int.Parse(Console.ReadLine());
            var column = int.Parse(Console.ReadLine());
            var price = 0.00;

            if (type == "Premiere")
            {
                price = row * column * 12.00;
                Console.WriteLine("{0:f2} leva", price);
            }
            else if (type == "Normal")
            {
                price = row * column * 7.50;
                Console.WriteLine("{0:f2} leva", price);
            }
            else
            {
                price = row * column * 5.00;
                Console.WriteLine("{0:f2} leva", price);
            }
        }
    }
}
