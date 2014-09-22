<%@ WebHandler Language="C#" Class="RssHandler" %>

using System;
using System.Web;

public class RssHandler : IHttpHandler
{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/xml";
        context.Response.Write("<f>Hello World</f>");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}