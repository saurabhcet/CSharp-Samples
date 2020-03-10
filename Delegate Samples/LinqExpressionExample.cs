using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Delegates
{
    //LINQ introduced the new type called Expression that represents strongly typed lambda expression.
    //The.NET compiler converts the lambda expression which is assigned to Expression<TDelegate> into an Expression tree instead of executable code.
    //This expression tree is used by remote LINQ query providers as a data structure to build a runtime query out of it(such as LINQ-to-SQL, EntityFramework or any other LINQ query provider that implements IQueryable<T> interface).
    public class LinqExpressionExample
    {
        public static void Start()
        {  
            //LINQ Expression
            Expression<Func<Student, bool>> isAdultExp = (s) => s.Age > 18;
            Expression<Func<Student, bool>> isMinorExp = (s) => s.Age < 18;

            Console.WriteLine("Print LINQ Expression: Adults");
            Print(isAdultExp);

            Console.WriteLine("Print LINQ Expression: Minor");
            Print(isMinorExp);
        }

        static void Print(Expression<Func<Student, bool>> exp)
        {
            IList<Student> students = new List<Student>() { new Student { Name = "Mr X", Age = 17 }, new Student { Name = "Mr Y", Age = 25 } };
            //     Compiles the lambda expression described by the expression tree into executable
            //     code and produces a delegate that represents the lambda expression.
            //   Predicate => Expression Tree => Provider(LINQ-to-SQL or EF etc) => Database
            Func<Student, bool> whereClause = exp.Compile();
            var adults = students
                        .Where(whereClause);
            foreach (var s in adults)
                Console.WriteLine($"{s.Name}, {s.Age}");
        }
    }
}