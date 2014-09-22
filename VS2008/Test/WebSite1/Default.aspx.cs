using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Class1 c = new Class1();
     
            throw new Exception("fds");
      
       // Response.Write(Server.GetLastError());
        ClassLibrary1.Class1.test();
        //Assembly asm = Assembly.GetAssembly(typeof(ClassLibrary1.Class1));
        //if (asm != null)
        //{
        //    AssemblyName assembly = asm.GetName();
        //    byte[] key = assembly.GetPublicKey();
        //    bool isSigned = key.Length > 0;
        //    Console.WriteLine("Is signed: {0}", isSigned);
        //}

        //asm = Assembly.GetAssembly(typeof(ClassLibrary1.Class1));
        //if (asm != null)
        //{
        //    AssemblyName assembly = asm.GetName();
        //    byte[] key = assembly.GetPublicKey();
        //    bool isSigned = key.Length > 0;
        //    Console.WriteLine("Is signed: {0}", isSigned);
        //}
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Class1 c = new Class1();
        string s = FormatObjectToXml(c);
        c.Tint = 1;
        c.TQint = 2;
        c.Tstring = "";
        string ss = FormatObjectToXml(c);
        Response.Write(c.GetDate());
    }

    public static string FormatObjectToXml(object obj)
    {
        XmlSerializer Serializer = new XmlSerializer(obj.GetType());
        //声明内存块
        Stream memoryStream = new MemoryStream();
        //声明写内存对象
        TextWriter textWriter = new StreamWriter(memoryStream);
        //将XML序列化到内存中
        Serializer.Serialize(textWriter, obj);

        // 设置内存流的起始位置 
        memoryStream.Position = 0;
        StreamReader reader = new StreamReader(memoryStream);
        string xmlValue = reader.ReadToEnd();
        //关闭流
        memoryStream.Close();
        textWriter.Close();
        reader.Close();
        return xmlValue;
    }

    protected override void OnError(EventArgs e)
    {

        //重定向到错误页
         Server.Transfer("~/default2.aspx");
        base.OnError(e);
    }
}
