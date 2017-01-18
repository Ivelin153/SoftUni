using System;
namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = int.Parse(Console.ReadLine());
            var foodLeft = int.Parse(Console.ReadLine());
            var foodForDogPerDay = double.Parse(Console.ReadLine());
            var foodForCatPerDay = double.Parse(Console.ReadLine());
            var foodForTurtlePerDay = double.Parse(Console.ReadLine());

            var foodForDog = days * foodForDogPerDay;
            var foodForCat = days * foodForCatPerDay;
            var foodForTurtle = days * (foodForTurtlePerDay / 1000);

            var totalFood = foodForDog + foodForCat + foodForTurtle;
            var difference = Math.Abs(foodLeft - totalFood);

            if (foodLeft >= totalFood)
            {
                Console.WriteLine("{0} kilos of food left.", Math.Floor(difference));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed.",Math.Ceiling(difference));
            }
        }
    }
}
