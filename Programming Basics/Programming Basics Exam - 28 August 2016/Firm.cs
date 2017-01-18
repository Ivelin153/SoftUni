using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            var hoursNeeded = int.Parse(Console.ReadLine());
            var daysForWork = int.Parse(Console.ReadLine());
            var offtimeWorkers = int.Parse(Console.ReadLine());

            var timeAfterEducation = daysForWork - (daysForWork * 0.1);
            var timeForWork = timeAfterEducation * 8;
            var overtimeWork = offtimeWorkers * (2 * daysForWork);
            var totalWorkingTime = Math.Floor(timeForWork + overtimeWork);

            if (totalWorkingTime >= hoursNeeded)
            {
                Console.WriteLine("Yes!{0} hours left.", totalWorkingTime - hoursNeeded);
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", hoursNeeded - totalWorkingTime);
            }
        }
    }
}
