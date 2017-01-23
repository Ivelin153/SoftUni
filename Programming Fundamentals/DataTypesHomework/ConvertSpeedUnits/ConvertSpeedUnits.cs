using System;
namespace ConvertSpeedUnits
{
    class ConvertSpeedUnits
    {
        static void Main(string[] args)
        {
            var distanceInMeters = int.Parse(Console.ReadLine());
            var hours = float.Parse(Console.ReadLine());
            var minutes = float.Parse(Console.ReadLine());
            var seconds = float.Parse(Console.ReadLine());

            float distanceInMiles = distanceInMeters / 1609.00f;
            float timeInSeconds = hours * 3600 + minutes * 60 + seconds;
            float speedInMetersPerSecond = distanceInMeters / timeInSeconds;
            float speedInKmPerHour = speedInMetersPerSecond * 3600 / 1000;
            //float speedInKmPerHour = (distanceInMeters / 1000) / (seconds / 360 + minutes / 60 + hours);
            float speedInMilesPerHour = distanceInMiles / (seconds / 3600 + minutes / 60 + hours);
            Console.WriteLine("{0:f7}", speedInMetersPerSecond.ToString());
            Console.WriteLine("{0:f7}", speedInKmPerHour.ToString());
            Console.WriteLine("{0:f7}", speedInMilesPerHour.ToString());
        }
    }
}
