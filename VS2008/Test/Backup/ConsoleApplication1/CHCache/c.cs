using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace ConsoleApplication1.CHCache
{
    class c
    {
    }

    namespace CHCache
    {
        /// <summary>
        /// 缓存介质
        /// </summary>
        public class Medium
        {
            /// <summary>
            /// 主要存储介质
            /// </summary>
            public object Primary { get; set; }
            /// <summary>
            /// 次要存储介质
            /// </summary>
            public object Secondary { get; set; }
            /// <summary>
            /// 是否正在使用主要存储
            /// </summary>
            public bool IsPrimary { get; set; }
            /// <summary>
            /// 是否正在更新
            /// </summary>
            public bool IsUpdating { get; set; }
            /// <summary>
            /// 是否更新完成
            /// </summary>
            public bool IsUpdated { get; set; }
        }




        /*
         * http://www.cnblogs.com/chsword/
         * chsword
         * Date: 2009-3-31
         * Time: 17:00
         * 
         */


        /// <summary>
        /// 双存储的类
        /// </summary>
        public class DictionaryCache : IEnumerable
        {
            /// <summary>
            /// 在此缓存构造时初始化字典对象
            /// </summary>
            public DictionaryCache()
            {
                Store = new Dictionary<string, Medium>();
            }
            public void Add(string key, Func<object> func)
            {
                if (Store.ContainsKey(key))
                {//修改，如果已经存在，再次添加时则采用其它线程
                    var elem = Store[key];
                    if (elem.IsUpdating) return;  //正在写入未命中
                    var th = new ThreadHelper(elem, func);//ThreadHelper将在下文提及,是向其它线程传参用的
                    var td = new Thread(th.Doit);
                    td.Start();
                }
                else
                {//首次添加时可能也要读取，所以要本线程执行
                    Console.WriteLine("Begin first write" + DateTime.Now);
                    Store.Add(key, new Medium { IsPrimary = true, Primary = func() });
                    Console.WriteLine("End first write" + DateTime.Now);
                }

            }
            /// <summary>
            /// 读取时所用的索引
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public object this[string key]
            {
                get
                {
                    if (!Store.ContainsKey(key)) return null;
                    var elem = Store[key];
                    if (elem.IsUpdated)
                    {//如果其它线程更新完毕，则将主次转置
                        elem.IsUpdated = false;
                        elem.IsPrimary = !elem.IsPrimary;
                    }
                    var ret = elem.IsPrimary ? elem.Primary : elem.Secondary;
                    var b = elem.IsPrimary ? " from 1" : " form 2";
                    return ret + b;
                }
            }
            Dictionary<string, Medium> Store { get; set; }
            public IEnumerator GetEnumerator()
            {
                return ((IEnumerable)Store).GetEnumerator();
            }
        }

        public class ThreadHelper
        {
            Func<object> Fun { get; set; }
            Medium Medium { get; set; }
            /// <summary>
            /// 通过构造函数来传递参数
            /// </summary>
            /// <param name="m">缓存单元</param>
            /// <param name="fun">读取数据的委托</param>
            public ThreadHelper(Medium m, Func<object> fun)
            {
                Medium = m;
                Fun = fun;
            }
            /// <summary>
            /// 线程入口，ThreadStart委托所对应的方法
            /// </summary>
            public void Doit()
            {
                Medium.IsUpdating = true;
                if (Medium.IsPrimary)
                {
                    Console.WriteLine("Begin write to 2."+DateTime.Now);
                    var ret = Fun.Invoke();
                    Medium.Secondary = ret;
                    Console.WriteLine("End write to 2." + DateTime.Now);
                }
                else
                {
                    Console.WriteLine("Begin write to 1." + DateTime.Now);
                    var ret = Fun.Invoke();
                    Medium.Primary = ret;
                    Console.WriteLine("End write to 1." + DateTime.Now);
                }
                Medium.IsUpdated = true;
                Medium.IsUpdating = false;
            }

            public static void main(string[] args)
            {
                var cache = new DictionaryCache();
                Console.WriteLine("Init...4s，you can press the CTRL+C to close the console window.");
                int i = 0;
                while (true)
                {
                    i++;
                   // Console.WriteLine("begin cache.Add(1, GetValue);"+DateTime.Now);
                    cache.Add("1", GetValue);
                   // Console.WriteLine("end cache.Add(1, GetValue);"+DateTime.Now);
                    Console.WriteLine(cache["1"]);
                    Thread.Sleep(1000);
                    Console.WriteLine(cache["1"]);
                    if (i > 10)
                        break;
                }
                while (true)
                {
                    i++;
                    Thread.Sleep(100);
                    Console.WriteLine(cache["1"]+"---------30"+DateTime.Now);
                    if (i > 3)
                        break;
                }
            }
            /// <summary>
            /// 获取数据的方法，假设是从数据库读取的，费时约4秒
            /// </summary>
            /// <returns></returns>
            static object GetValue()
            {
                Thread.Sleep(4000);
                return DateTime.Now;
            }
        }


    }
}
