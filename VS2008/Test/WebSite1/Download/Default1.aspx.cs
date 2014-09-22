using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CookieTest_Default1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string Address
    {
        get
        {
            //int index = Request.Url.AbsoluteUri.LastIndexOf("/");
            //int length = Request.Url.AbsoluteUri.Length;
            //return Page.Request.Url.AbsoluteUri.Remove(index, length - index) + "/Comparision1.aspx";
            return Request.Url.Authority + "/ItemHistory/Comparision1.aspx";
        }
    }
}
