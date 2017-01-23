using System;
namespace TriplesOfLetter
{
    class TriplesOfLetter
    {
        static void Main(string[] args)
        {
            var letters = int.Parse(Console.ReadLine());
            for (char letter1 = 'a'; letter1 < 'a' + letters; letter1++)
                for (int letter2 = 'a'; letter2 < 'a' + letters; letter2++)
                    for (int letter3 = 'a'; letter3 < 'a' + letters; letter3++)
                    {
                        Console.WriteLine("{0}{1}{2}",
                            (char)letter1,
                            (char)letter2,
                            (char)letter3);
                    }

        }
    }
}
