using System;
namespace HelloName
{
    public class HelloName
    {
        public static void Main()
        {
            PrintName("Peter");
        }

        public static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
