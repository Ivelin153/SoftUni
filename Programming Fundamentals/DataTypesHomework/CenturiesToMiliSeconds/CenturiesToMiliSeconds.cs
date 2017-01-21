using System;

namespace CenturiesToMiliSeconds
{
    class CenturiesToMiliSeconds
    {
        static void Main(string[] args)
        {
            var centuries = int.Parse(Console.ReadLine());
            var years = centuries * 100;
            var days = years * 365.2422;
            var hours = (int)days * 24;
            var minutes = hours * 60;
            ulong seconds = (ulong)minutes * 60;
            ulong miliseconds = seconds * 1000;
            ulong microseconds = miliseconds * 1000;
            ulong nanoseconds = microseconds * 1000;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} miliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
