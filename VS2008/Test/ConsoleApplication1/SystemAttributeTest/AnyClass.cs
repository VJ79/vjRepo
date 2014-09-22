using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

[assembly: ConsoleApplication1.Help("fds", Version = "fds")]
namespace ConsoleApplication1
{
    


    [Help("fds", Version = "fds")]
    public class AnyClass
    {
        string s;
        public string sst
        {
            get
            {
                return s;
            }
        }

        [Help("fds", Version = "fds")]
        public void test1()
        { }
        [Help("fds", Version = "fds")]
        public static void test()
        {
            HelpAttribute HelpAttr;


            //Querying Assembly Attributes

            String assemblyName;

            System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();

            assemblyName = p.ProcessName + ".exe";


             Assembly a = Assembly.LoadFrom(assemblyName);

            object[] attributeArr=a.GetCustomAttributes(false);
            foreach (Attribute attr in attributeArr)
            {

                HelpAttr = attr as HelpAttribute;

                if (null != HelpAttr)
                {

                    Console.WriteLine("Description of {0}:\n{1}",

                                      assemblyName, HelpAttr.Description);

                }

            }

            Type type = typeof(AnyClass);

            object[] attributes = type.GetCustomAttributes(true);
            foreach (Attribute attr in attributes)
            {

                HelpAttr = attr as HelpAttribute;

                if (null != HelpAttr)
                {

                    Console.WriteLine("Description of {0}:\n{1}",

                                      assemblyName, HelpAttr.Description);

                }

            }

            foreach (MethodInfo method in type.GetMethods())
            {

                foreach (Attribute attr in method.GetCustomAttributes(true))
                {

                    HelpAttr = attr as HelpAttribute;

                    if (null != HelpAttr)
                    {

                        Console.WriteLine("Description of {0}:\n{1}",

                                          method.Name,

                                          HelpAttr.Description);

                    }

                }

            }


            //Querying Class-Field (only public) Attributes

            foreach (FieldInfo field in type.GetFields())
            {

                foreach (Attribute attr in field.GetCustomAttributes(true))
                {

                    HelpAttr = attr as HelpAttribute;

                    if (null != HelpAttr)
                    {

                        Console.WriteLine("Description of {0}:\n{1}",

                                          field.Name, HelpAttr.Description);

                    }

                }

            }
            
        }
    }

}
