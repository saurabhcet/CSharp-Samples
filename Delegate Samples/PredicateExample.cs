using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Delegates
{

    // It represents a method that contains a set of criteria and checks whether the passed parameter meets those criteria or not. 
    // A predicate delegate methods must take one input parameter and return a boolean - true or false
    public class PredicateExample
    {
        //public delegate bool IsAdultPerCountry(Student s, int countryMinAge);
        public static void Start()
        {
            Console.WriteLine("Print - Anonymous Method");
            Predicate<Student> isAdult = delegate (Student s) { return s.Age >= 18; };
            Console.WriteLine(isAdult(new Student() { Age = 25 }));

            Console.WriteLine("Print - Lambda Expression");
            Predicate<Student> isAdultLE = (s) => s.Age >= 18; 
            Console.WriteLine(isAdultLE(new Student() { Age = 25 }));
        }
    }
}