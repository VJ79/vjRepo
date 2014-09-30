using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ConsoleApplication1
{
    public partial class Class1
    {
        partial void Added(string s)
        {
            Console.WriteLine(s + DateTime.Now.ToString());
        }
    }
    class Program
    {

        static void Main()
        {
            ClassLibrary1.Program.test();
            AnyClass.test();
            //ConsoleApplication1.SQLserver.Xml.testXML();
            ConsoleApplication1.ExpressionTest.test.tes();
        }
    }
}
