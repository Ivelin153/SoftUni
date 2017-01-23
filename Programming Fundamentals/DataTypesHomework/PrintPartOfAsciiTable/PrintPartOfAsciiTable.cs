using System;
namespace PrintPartOfAsciiTable
{
    class PrintPartOfAsciiTable
    {
        static void Main(string[] args)
        {
            var firstChar = int.Parse(Console.ReadLine());
            var lastChar = int.Parse(Console.ReadLine());

            for (int printChar = firstChar ; printChar <= lastChar; printChar++)
            {
                Console.Write((char)printChar + " ");
            }
        }
    }
}
