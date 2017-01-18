using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfStudents = int.Parse(Console.ReadLine());
            var fail = 0.00;
            var avarage = 0.00;
            var good = 0.00;
            var top = 0.00;
            var students = 0.00;
            var avarageGrade = 0.00;

            for (int i = 0; i < numberOfStudents; i++)
            {
                students++;
                var grades = double.Parse(Console.ReadLine());
                avarageGrade += grades;
                if (grades < 3.00)
                {
                    fail++;
                }
                else if (grades < 4.00)
                {
                    avarage++;
                }
                else if (grades < 5.00)
                {
                    good++;
                }
                else
                {
                    top++;
                }
            }
            var AvarageGrade = avarageGrade / students;

            Console.WriteLine("Top students: {0:f2}%", top / numberOfStudents * 100);
            Console.WriteLine("Between 4.00 and 4.99: {0:f2}%", good / numberOfStudents * 100);
            Console.WriteLine("Between 3.00 and 3.99: {0:f2}%", avarage / numberOfStudents * 100);
            Console.WriteLine("Fail: {0:f2}%", fail / numberOfStudents * 100);
            Console.WriteLine("Average: {0:f2}", AvarageGrade);
        }
    }
}


