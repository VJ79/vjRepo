using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ClassLibrary2
{
    public class Class1
    {
        public static void test()
        {
            Console.Write("fds2");

            ClassLibrary1.Class1.test();
            Assembly asm = Assembly.GetAssembly(typeof(ClassLibrary2.Class1));
            if (asm != null)
            {
                AssemblyName assembly = asm.GetName();
                byte[] key = assembly.GetPublicKey();
                bool isSigned = key.Length > 0;
                Console.WriteLine("Is signed: {0}", isSigned);
            }
        }
    }
}
