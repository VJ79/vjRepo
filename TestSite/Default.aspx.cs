using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Response.Clear();
      //  Response.ContentType = "text/xml";
      // // Response.ContentEncoding = Encoding.UTF8;

      //  string sXml = "<ff><f>Hello World</f></ff>";// BuildXMLString(); //not showing this function, 
      //  //but it creates the XML string

      //Response.Write(sXml);
      //  Response.End();
        var q = Request.QueryString;
        var f = Request.Form;

    }
}
