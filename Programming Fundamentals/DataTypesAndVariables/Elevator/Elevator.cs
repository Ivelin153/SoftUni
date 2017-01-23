using System;
namespace Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            double numberOfPeople = double.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            var courses = numberOfPeople / capacity;
            Console.WriteLine(Math.Ceiling(courses));
        }
    }
}
