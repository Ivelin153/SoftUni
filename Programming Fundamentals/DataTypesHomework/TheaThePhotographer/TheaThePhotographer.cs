using System;
namespace TheaThePhotographer
{
    class TheaThePhotographer
    {
        static void Main(string[] args)
        {
            var takenPictures = int.Parse(Console.ReadLine());
            var filterTimeNeeded = int.Parse(Console.ReadLine());
            var percentOfGoodPhotos = int.Parse(Console.ReadLine());
            var uploadTime = int.Parse(Console.ReadLine());

            double goodPhotos = Math.Ceiling(takenPictures * (percentOfGoodPhotos / 100.0));
            long filterTime = takenPictures * (long)filterTimeNeeded;
            long timeForUpload = (long)goodPhotos * uploadTime;
            long totalTimeNeeded = filterTime + timeForUpload;            
            Console.WriteLine(TimeSpan.FromSeconds(totalTimeNeeded).ToString(new string('d', 1) + @"\:hh\:mm\:ss"));
        }
    }
}
