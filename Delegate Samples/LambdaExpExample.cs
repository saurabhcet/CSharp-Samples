using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Delegates
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }


    //Lambda expression can also be assigned to built-in delegates such as Func, Action and Predicate.
    public class LambdaExpExample
    {
        delegate bool IsAdult(Student s);
        delegate bool IsAdultPerCountry(Student s, int countryMinAge);

        public static void Start()
        {
            Student stud = new Student() { Age = 25 };

            //Anonymous Method
            IsAdult isAdult = delegate (Student s) { return s.Age > 18; };
            Console.WriteLine(isAdult(stud));

            //Lambda Expression
            //IsAdult isAdultLE = (Student s) => s.Age > 18; OR
            IsAdult isAdultLE = s => s.Age > 18;            
            Console.WriteLine(isAdultLE(stud));

            //Lambda Expression Multi Parameter
            IsAdultPerCountry isAdultPerIndia = (s, minAge) =>
                          {
                              Console.WriteLine($"Student Age: {s.Age}, MinAge:{minAge}");
                              return s.Age >= minAge;
                          };

            Console.WriteLine(isAdultPerIndia(stud, 18));
        }

        bool IsAdultFun(Student s)
        {
          return s.Age > 18;
        }
    }
}
