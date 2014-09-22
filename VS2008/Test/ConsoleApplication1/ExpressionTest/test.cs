using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ConsoleApplication1.ExpressionTest
{
    public class test
    {
        public static void tes()
        {
            // The expression tree to execute.
            BinaryExpression be = Expression.Power(Expression.Constant(2D), Expression.Constant(3D));

            // Create a lambda expression.
            Expression<Func<double>> le = Expression.Lambda<Func<double>>(be);

            // Compile the lambda expression.
            Func<double> compiledExpression = le.Compile();

            // Execute the lambda expression.
            double result = compiledExpression();

            // Display the result.
            Console.WriteLine(result);

            // This code produces the following output:
            // 8
            Expression<Predicate<int>> expression = (n) => n < 11;
            //bool ddd= expression.Compile()(3);
            //Expression<Predicate<double,double>,> expression = (n,m) => n < m;
            Func<string, bool> filter = s => s.Length == 5;
            Expression<Func<int,int,bool>> expression1 = (n,m) => n < m;
            bool bbbb= expression1.Compile()(2, 3);

            

        }

    }
}
