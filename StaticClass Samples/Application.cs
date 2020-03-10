using System;
using static StaticClass.Program;

namespace StaticClass
{
   public class Application
    {
        public static int Key = default;
        public static string Value = default;

        static int counter = 10; 
        public static void Start(PrintDelegate print)
        {
            Console.WriteLine($"{Key}, {Value}");
            
            // Perform some calculation
            for (int i = 1; i < counter; i++)
            {                
                Console.WriteLine($" Calculating: {i}");
                SetProperty(i, $" Calculating: {i}");

                print($"Printing: {i}");
            }
        }

        public static void Start2(IResponse p)
        {
            Console.WriteLine($"{Key}, {Value}");

            // Perform some calculation
            for (int i = 1; i < counter; i++)
            {
                Console.WriteLine($" Calculating: {i}");
                SetProperty(i, $" Calculating: {i}");

            p.Print($"Callback Printing: {i}");
            IResponse.DirectPrint($"Printing: {i}");
            }
        }

        public void Invoke(PrintDelegate print)
        {
            counter = 20;
            Start(print);
        }

        public static void SetProperty(int key, String value)
        {
            Key = key;
            Value = value;
        }
    }
}