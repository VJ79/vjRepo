/**************************************************************
 * this file is part of ClassLibrary1 Project
 * Copyright (C)1997-2009 CnSync Tech Corp.
 * 
 * Author      : wangj
 * Mail        : blueler@gmail.com
 * Create Date : 3/11/2009 3:05:38 PM 
 * Summary     : 
 * 
 * 
 * Modified By : 
 * Date        : 
 * Mail        : 
 * Comment     :   
 * *************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Collections;
namespace ClassLibrary1
{
    public class Class3
    {
        public string s;
        public int ii;
        public int? iii;

    }



public class C : IDisposable
{
    public void UseLimitedResource()
    {
        Console.WriteLine("Using limited resource...");
        List<Class3> clist = new List<Class3>();
        clist.Add(new Class3());
        Class3 ccc = new Class3();
        clist.Add(ccc);
        ccc.ii = 33;
        ccc.iii = 222;
        ccc.s = "fdsfdserer";
        string sss = FormatObjectToXml(clist);
    }

    public void Dispose()
    {
        
        
        Console.WriteLine("Disposing limited resource.");
    }

    /// <summary>
    /// 将泛型的Object序列化成一个XML的字符串
    /// </summary>        
    /// <param name="obj">泛型接口</param>
    /// <returns></returns>
    public static string FormatObjectToXml(object obj)
    {
        string xmlValue;
        XmlSerializer Serializer = new XmlSerializer(obj.GetType());
        //声明内存块
        using (Stream memoryStream = new MemoryStream())
        {
            //声明写内存对象
            TextWriter textWriter = new StreamWriter(memoryStream);

            //将XML序列化到内存中
            Serializer.Serialize(textWriter, obj);

            // 设置内存流的起始位置 
            memoryStream.Position = 0;
            StreamReader reader = new StreamReader(memoryStream);
            xmlValue = reader.ReadToEnd();

        }
        return xmlValue;
    }

    public string FormatListToString(XmlSerializer Serializer, IList list)
    {
        TextWriter textWriter;
        string xmlValue="";
        StreamReader reader;
        //声明内存块
        using (Stream memoryStream = new MemoryStream())
        {
            //声明写内存对象
            textWriter = new StreamWriter(memoryStream);
            //将XML序列化到内存中
            //Serializer.Serialize(textWriter, list);

            //// 设置内存流的起始位置 
            memoryStream.Position = 0;
            reader = new StreamReader(memoryStream);
            //xmlValue = reader.ReadToEnd();
            ////关闭流
            //memoryStream.Close();
            //textWriter.Close();
            //reader.Close();
        }

       
        return xmlValue;
    }

}

public class D : C
{
    public void hahah()
    {
        Console.Write(this.GetType().ToString());
    }
}

}
