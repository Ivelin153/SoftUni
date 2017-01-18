using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var days = int.Parse(Console.ReadLine());
            var treatedPatients = 0;
            var untreatedPatients = 0;
            var doctors = 7;

            for (int i = 1; i <= days; i++)
            {
                var patients = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    if (untreatedPatients > treatedPatients)
                    {
                        doctors++;
                    }
                }
                if (patients > doctors)
                {
                    treatedPatients += doctors;
                    untreatedPatients += (patients - doctors);
                }
                else
                {
                    treatedPatients += patients;
                }          
               
                
            }
            Console.WriteLine("Treated patients: {0}.", treatedPatients);
            Console.WriteLine("Untreated patients: {0}.", untreatedPatients);
        }
    }
}
