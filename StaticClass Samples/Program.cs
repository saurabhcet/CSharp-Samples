using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StaticClass
{
    public delegate void PrintDelegate(String value);

    public interface IResponse
    {

       public static void DirectPrint(String value)
       {
            Console.WriteLine($"Interface O/P: {value}");            
       }

        public void Print(String value)
        {
            Console.WriteLine($"Interface O/P: {value}");
        }
    }

    public class Program: IResponse
    {
        public static void Main()
        {
            for (int i = 0; i < 25; i++)
            {
                Init();
            }            
        }

        public static void Print(String value)
        {
            Console.WriteLine($"O/P value : {value}");
        }

        static void Init()
        {
            Console.WriteLine("Printing Static Class Properties");

            Console.WriteLine($"Key:{Application.Key}, Value: {Application.Value}");

            // Scope is limited to Calling program and loaded individually.
            Application.Key = 25;
            Application.Value = "Hello Static Class";

            Console.WriteLine($"Key:{Application.Key}, Value: {Application.Value}");

            Console.WriteLine("Sleeping for 100000 ms");
            Thread.Sleep(100);

            //Application.Start(Print);

            //IPrint p = () => { Console.WriteLine("Hello, I am a simple single func."); };

            IResponse p = new Program();

            Application.Start2(p);

            Console.WriteLine($"Key:{Application.Key}, Value: {Application.Value}");

            //Application app = new Application();
            //app.Invoke(Print);

            //Console.WriteLine($"Key:{Application.Key}, Value: {Application.Value}");
        }
    }
}
