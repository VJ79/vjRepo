using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public partial class Class1
    {
        public static void test()
        {
           
            Console.Write("fds");

        }
        public string tt()
        {
            throw new Exception(this.ToString());
            return "";
        }

        partial void Added(string s);

        public  void Add(string s)
        {
            Console.WriteLine(s);
            Added(s);
        }
    }
}
