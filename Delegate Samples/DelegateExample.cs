using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Delegates
{

    // Action delegate is same as func delegate except that it does not return anything. Return type must be void.
    public class DelegateExample
    {
        delegate void IsAdult(Student s);
        
        public static void StudentIsAdult(Student s)
        {
            Console.WriteLine($"This student is an adult, Age: {s.Age}");
        }

        public static void StudentIsNotAKid(Student s)
        {
            Console.WriteLine($"This student is not a kid, Age: {s.Age}");
        }

        public static void Start()
        {
            Console.WriteLine("Print: Delegate");
            Calculate(new Student() { Age = 25 }, StudentIsAdult);

            Console.WriteLine("Print: Multicast Delegate");
            IsAdult printDel = StudentIsAdult;
            printDel += StudentIsNotAKid;
            CalculateMultiCast(new Student() { Age = 25 }, printDel);
        }

        static void Calculate(Student s, IsAdult callBack)
        {
            if (s.Age > 18)
                callBack(s);
            // OR callBack.Invoke(s);
        }
        static void CalculateMultiCast(Student s, IsAdult callBack)
        {
            if (s.Age < 5)
                callBack -= StudentIsNotAKid; // Bad coding style to expose delegate like 

            if (s.Age > 18)
                callBack(s);            
        }
    }
}