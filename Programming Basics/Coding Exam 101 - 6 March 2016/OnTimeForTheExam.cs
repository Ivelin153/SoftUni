using System;


namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {

            var hourOfExam = int.Parse(Console.ReadLine());
            var minOfExam = int.Parse(Console.ReadLine());
            var hourOfArrival = int.Parse(Console.ReadLine());
            var minOfArrival = int.Parse(Console.ReadLine());

            var examTime = hourOfExam * 60 + minOfExam;
            var studentTime = hourOfArrival * 60 + minOfArrival;
            var minutesDifference = studentTime - examTime;

            if (minutesDifference < -30)
                Console.WriteLine("Early");
            else if (minutesDifference <= 0)
                Console.WriteLine("On time");
            else
                Console.WriteLine("Late");

            if (minutesDifference != 0)
            {
                var hours = Math.Abs(minutesDifference / 60);
                var minutes = Math.Abs(minutesDifference % 60);
                if (hours > 0)
                {
                    if (minutes < 10)
                        Console.Write(hours + ":0" + minutes + " hours");
                    else
                        Console.Write(hours + ":" + minutes + " hours");
                }
                else
                    Console.Write(minutes + " minutes");
                if (minutesDifference < 0)
                    Console.WriteLine(" before the start");
                else
                    Console.WriteLine(" after the start");
            }
        }
    }
}
