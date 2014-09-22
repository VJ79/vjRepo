using System;
using System.Collections.Generic;
using System.Text;


using System.Reflection;
using AXzhz.test.Resource;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace AXzhz.test.Resource
{
    public class Class1
    {
        public string ResourceTest()
        {

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager("AXzhz.test.Resource.Resource", Assembly.GetExecutingAssembly());
            string s = rm.GetString("String1", Thread.CurrentThread.CurrentCulture);//new System.Globalization.CultureInfo("ja")

            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            System.Resources.ResourceManager rm1 = new System.Resources.ResourceManager("AXzhz.test.Resource.TextFile1", Assembly.GetExecutingAssembly());
            s = rm1.GetString("a");
            return s;
    
        }
    }
}
