using System;


namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                Console.Write(new string(' ', n - row));
                for (int j = 1; j <= row; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine(new string(' ', row));
            }

            for (int i = n - 1; i > 0; i--)
            {
                Console.Write(new string(' ', n - i));
                for (int j = 0; j < i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine(new string(' ', n - i));
            }

        }
    }
}
