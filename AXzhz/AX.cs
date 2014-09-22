using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Text;


    public class AX : System.Web.UI.Page, IHttpHandler
    {
        //如果URL为*.ax,则执行下面的方法
        public new void ProcessRequest(HttpContext context)
        {
            /**/
            /*当前上下文的请求
    删除后,出现:
    异常详细信息: System.Web.HttpException: 请求在此上下文中不可用*/
            HttpRequest Request = context.Request;

            //获取域名后面的内容
            string strPathAndQuery = Request.Url.PathAndQuery;
            //取出URL最后面的页面名
            string filename = strPathAndQuery.Substring(strPathAndQuery.LastIndexOf("/"), strPathAndQuery.LastIndexOf(".") - strPathAndQuery.LastIndexOf("/"));
            //设定要转向的网页
            Server.Transfer("~/" +  "Default.aspx");
            /**/
            /*下面这句话可以使任何以.ax后缀的URL转向到
    一个固定的相对路径网页target.aspx上*/
            //Server .Transfer ("/target/target.aspx");

        }
        //HttpHandler被设置为同步。同步处理程序在完成对为其调用该处理程序的 HTTP 请求的处理后才会返回。
        public new bool IsReusable
        {
            get { return false; }
        }
   
}
