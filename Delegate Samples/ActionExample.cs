using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Delegates
{

    // Action delegate is same as func delegate except that it does not return anything. Return type must be void.
    public class ActionExample
    {
        //public delegate bool IsAdultPerCountry(Student s, int countryMinAge);
        public static void Start()
        {
            Console.WriteLine("Print: Action- Anonymous Method");
            Action<Student, int> printResult = delegate(Student s, int countryMinAge) { Console.WriteLine(s.Age >= countryMinAge); };
            printResult(new Student() { Age = 25 }, 10);

            Console.WriteLine("Print: Action- Lambda Expression");
            Action<Student, int> printResultLE = (s, countryMinAge) => Console.WriteLine(s.Age >= countryMinAge);
            printResultLE(new Student() { Age = 25 }, 10);
        }
    }
}