using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Program
    {
        public static void test()
        {
            Action a = new Action();
            ActionInvocation invoker = new ActionInvocation(a);
            invoker.invoke();
            Console.ReadLine();
        }
    }

    public class Action
    {
        public void Execute()
        {
            Console.WriteLine("Action invoked");
        }
    }

    public interface Interceptor
    {
        void Intercept(ActionInvocation actionInvocation);
    }

    public class Interceptor1 : Interceptor
    {
        public void Intercept(ActionInvocation actionInvocation)
        {
            Console.WriteLine("=======*1");
            actionInvocation.invoke();
            Console.WriteLine("=======*-1");
        }
    }

    public class Interceptor2 : Interceptor
    {
        public void Intercept(ActionInvocation actionInvocation)
        {
            Console.WriteLine("=======*2");
            actionInvocation.invoke();
            Console.WriteLine("=======*-2");
        }
    }



    public class ActionInvocation
    {

        List<Interceptor> interceptors = new List<Interceptor>();
        int index = -1;
        Action action = null;

        public ActionInvocation(Action action)
        {
            this.action = action;
            this.interceptors.Add(new Interceptor1());
            this.interceptors.Add(new Interceptor2());
        }

        public void invoke()
        {
            index++;
            if (index >= this.interceptors.Count)
            {
                action.Execute();
            }
            else
            {
                this.interceptors[index].Intercept(this);
            }
        }
    }
}