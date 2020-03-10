using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    //Lambda Expression is a shorter way of representing anonymous method
    public class LinqExample
    {
        public static void Start()
        {           
            IList<Student> students = new List<Student>() { new Student { Name = "Mr X" , Age = 20 }, new Student { Name = "Mr Y", Age = 25 }};

            //Anonyomus Method in LINQ Method Syntax
            var adults = students.Where(delegate (Student s) { return s.Age > 18; });
            foreach (var s in adults)
                Console.WriteLine($"{s.Name}, {s.Age}");

            //Func Delegate in LINQ Method Syntax
            Func<Student, bool> isAdult = (s) => s.Age > 18;
            Func<Student, string> orderbyName = (s) => s.Name;
            adults = students
                        .Where(isAdult)
                        .OrderBy(orderbyName);
            foreach (var s in adults)
                Console.WriteLine($"{s.Name}, {s.Age}");


            //Func Delegate in LINQ Query Syntax
            adults = from s in students
                        where isAdult(s)
                     select s;
            foreach (var s in adults)
                Console.WriteLine($"{s.Name}, {s.Age}");
        }
    }
}