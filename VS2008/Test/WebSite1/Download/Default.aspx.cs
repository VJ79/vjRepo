using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Threading;

public partial class Download_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //using (System.IO.StreamReader sr = new System.IO.StreamReader("E:\\a.xls"))
        //{
        //    System.IO.Stream ss=sr.BaseStream;
        //    byte[] b=new byte[1000];
            
        //    ss.Read(b,0,1000);
        //    string str = System.Text.Encoding.Default.GetString( b );


        //    HttpContext.Current.Response.Clear();
        //    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("a.xls"));

        //    HttpContext.Current.Response.AddHeader("Content-Length", "1000");
        //    HttpContext.Current.Response.ContentType = "application/octet-stream";
        //    HttpContext.Current.Response.Write(str);//.WriteFile(fi.FullName, 0, fi.Length);
        //    HttpContext.Current.Response.Flush(); 
        //}

        ResponseFile("df.xls", "E:\\a.xls", 10000);
        //Response.WriteFile("E:\\a.txt");
    }

    // <summary>
    /// 输出硬盘文件，提供下载
    /// </summary>  
    /// <param name="_fileName">下载文件名</param>
    /// <param name="_fullPath">带文件名下载路径</param>
    /// <param name="_speed">每秒允许下载的字节数</param>
    /// <returns>返回是否成功</returns>
    public static bool ResponseFile(string _fileName, string _fullPath, long _speed)
    {
        HttpRequest _Request = System.Web.HttpContext.Current.Request;
        HttpResponse _Response = System.Web.HttpContext.Current.Response;
        try
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Stream stream = myFile;
            BinaryReader br = new BinaryReader(myFile);
            try
            {
                _Response.AddHeader("Accept-Ranges", "bytes");
                _Response.Buffer = false;
                long fileLength = stream.Length;
                long startBytes = 0;

                int pack = 10240; //10K bytes
                //int sleep = 200;   //每秒5次   即5*10K bytes每秒
                int sleep = (int)Math.Floor((decimal)1000 * pack / _speed) + 1;
                if (_Request.Headers["Range"] != null)
                {
                    _Response.StatusCode = 206;
                    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                _Response.AddHeader("Connection", "Keep-Alive");
                _Response.ContentType = "application/octet-stream";
                _Response.Charset = "UTF-8";
                _Response.ContentEncoding = Encoding.UTF8;
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, Encoding.UTF8));

                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((decimal)(fileLength - startBytes) / pack) + 1;

                for (int i = 0; i < maxCount; i++)
                {
                    if (_Response.IsClientConnected)
                    {
                        _Response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
                _Response.Flush();
            }
            catch (Exception err)
            {
                return false;
            }
            finally
            {
                br.Close();
                myFile.Close();
            }

        }
        catch (Exception err)
        {
            return false;
        }
        return true;
    }
}
