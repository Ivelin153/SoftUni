using System;
namespace ReverseCharacters
{
    class ReverseCharacters
    {
        static void Main(string[] args)
        {
            var letter1 = char.Parse(Console.ReadLine());
            var letter2 = char.Parse(Console.ReadLine());
            var letter3 = char.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{2}",
               letter3,
                (char)letter2,
                (char)letter1);
        }
    }
}
