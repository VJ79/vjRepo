using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class studenttest
    {
        public static void test()
        {
            DataClasses1DataContext dcdc = new DataClasses1DataContext();
            var student = (from s in dcdc.students
                          where s.id==1
                          select s);

            foreach (var s in student)
            {
                s.name = "hehe";
            }
            dcdc.SubmitChanges();
           
            
        }
    }
}
