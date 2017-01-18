using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            var number = int.Parse(Console.ReadLine());
            var letter = int.Parse(Console.ReadLine());

            for (int n1 = 1; n1 <= number; n1++)
                for (int n2 = 1; n2 <= number; n2++)
                    for (var l1 = 'a'; l1 < 'a' + letter; l1++)
                        for (var l2 = 'a'; l2 < 'a' + letter; l2++)
                            for (var n3 = Math.Max(n1, n2) + 1; n3 <= number; n3++)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ",
                                    n1, n2, l1, l2, n3);
                            }
            Console.WriteLine();
        }

    }
}

