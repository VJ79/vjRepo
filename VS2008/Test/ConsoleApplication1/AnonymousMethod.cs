using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public  class AnonymousMethod
    {
       public static void test()
       {
           string[] list = new string[] { "abc", "12", "java" };
           string[] ll = Array.FindAll(list,
               delegate(string s)
               {
                   return s.IndexOf("a") >= 0;
               }
               );
           foreach (string var in ll)
           {
               Console.WriteLine(var);
           }
           Console.ReadLine();
       }

       public static void test1()
       {
           string[] list = new string[] { "abc", "12", "java" };

           
           string[] ll = Array.FindAll(list, b);
           foreach (string var in ll)
           {
               Console.WriteLine(var);
           }
           Console.ReadLine();
       }

       public static bool b(string s)
       {
           return  s.IndexOf("a") >= 0;
           
       }
   }
}
