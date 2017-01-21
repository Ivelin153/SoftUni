using System;
namespace HexVariable
{
    class HexVariable
    {
        static void Main(string[] args)
        {
            var hex1 = Console.ReadLine();            
            Console.WriteLine(Convert.ToInt32(hex1, 16));           
        }
    }
}
