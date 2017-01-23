using System;
namespace Greetings
{
    class RefactoredPyramidVolume
    {
        static void Main(string[] args)
        {
            
            Console.Write("Length: ");
            double length = 0;
            length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = 0;
            width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = 0;
            height = double.Parse(Console.ReadLine());
            double volume = 0.00;
            volume = (length * width * height) / 3;
            Console.WriteLine("Pyramid Volume: {0:F2}", volume);

        }
    }
}

