using System;

namespace Delegates
{
    public class EventExample
    {
       public delegate bool IsAdult(Student s);
        // Usage as delegate
        // public IsAdult isAdult = StudentIsAdult;

       public event IsAdult StudentEvt;       

        public void ShowStudent(Student s)
        {
            bool isAdult = default;
            if (StudentEvt != null)
                isAdult = StudentEvt(s);

            Console.WriteLine($"Student Details: Name- {s.Name}, Age- {s.Age}, Adult: {isAdult} ");
        }

        public static bool IsStudentAdult(Student s)
        {            
            Console.WriteLine($"Invoking event");
            return s.Age > 18 ? true : default;
        }

        public static void PrintInfo(Student s)
        {
            Console.WriteLine($"Student: Name- {s.Name}, Age- {s.Age}");          
        }

        public static void Start()
        {
            Console.WriteLine("Print: Event");
            EventExample eventExample = new EventExample();
            eventExample.StudentEvt += IsStudentAdult;            
            eventExample.ShowStudent(new Student { Id = 1, Name = "Mr X", Age = 25 });
        }
    }
}