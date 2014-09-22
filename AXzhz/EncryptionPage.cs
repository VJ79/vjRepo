using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Collections.Specialized;
namespace AXzhz
{
    public class EncryptionPage : System.Web.UI.Page
    {
        public new HttpRequest Request
        {
            get
            {
                //NameValueCollection coll = base.Request.QueryString;
            //    NameValueCollection newcoll = new NameValueCollection();
                //String[] arr1 = coll.AllKeys;
                //for (int loop1 = 0; loop1 < arr1.Length; loop1++)
                //{
                //    Response.Write("Key: " + Server.HtmlEncode(arr1[loop1]) + "<br>");
                //    String[] arr2 = coll.GetValues(arr1[loop1]);
                //    for (loop2 = 0; loop2 < arr2.Length; loop2++)
                //    {
                //        Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
                //    }
                //}

                string s = base.Request.QueryString[0];
                //解密TBD
                //....
                //
                string[] queryString = s.Split('&');
                NameValueCollection nvc = base.Request.QueryString;
                nvc.Clear();
                for (int i = 0; i < queryString.Length; i++)
                {
                    if (queryString[i].Contains("="))
                    {
                        //"="号的位置
                        int temp = queryString[i].IndexOf('=');
                        string key = queryString[i].Substring(0, temp).Trim();
                        string value = queryString[i].Substring(temp + 1).Trim();
                        if (key.Length == 0)
                        {
                            //异常
                        }
                        base.Request.QueryString.Set(key, value);
                    }                    
                    
                }
                return base.Request;
            }

        }
    }
}