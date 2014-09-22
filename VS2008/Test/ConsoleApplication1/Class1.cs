using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    public partial class Class1 : ClassLibrary1.Interface1
    {
        public string GetNName()
        {

            return "ffffds";
        }
        public string test
        {
            get;
            set;
        }

        public void Add(string s)
        {
            Console.WriteLine(s);
            Added(s);
        }

         partial void Added(string s);


    }

    public enum SyncState
    {
        //同意
        ACCEPTED,
        //拒绝
        REJECTED,
        //重发 
        REVIEW,
        //己同步
        SYNCHRONISED
    }
}
