using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Delegates
{
    //Lambda expression can also be assigned to built-in delegates such as Func, Action and Predicate.

    // Func is a generic delegate included in the System namespace.
    // It has zero to 16 input parameters and one out parameter.
    // The last parameter is considered as an out parameter.  
    // Func delegate does not allow ref and out parameters.
    // Func delegate type can be used with an anonymous method or lambda expression.

    public class FuncExample
    {
        //public delegate TResult Func<in T, out TResult>(T arg); 
        //public delegate bool IsAdultPerCountry(Student s, int countryMinAge);
        public static void Start()
        {
            // Func<Student, int, bool> isAdult = IsAdultPerCountry;

            Console.WriteLine("Print: Func- Anonymous Method");
            Func<Student, int, bool> isAdult = delegate (Student s, int countryMinAge) { return s.Age >= countryMinAge; };
            bool result = isAdult(new Student() { Age = 25 }, 10);
            Console.WriteLine(result);

            Console.WriteLine("Print: Func- Lambda Expression");            
            Func<Student, int, bool> isAdultLE = (s, countryMinAge) => s.Age >= countryMinAge;
            result = isAdult(new Student() { Age = 25 }, 10);
            Console.WriteLine(result);
        }

       static bool IsAdultPerCountry (Student s, int countryMinAge) => s.Age >= countryMinAge;                          
    }
}