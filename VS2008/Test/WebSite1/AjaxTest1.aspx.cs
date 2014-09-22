using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AjaxTest1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // DropDownList1.Attributes.Add("onchange", "test()");
        Ajax.Utility.RegisterTypeForAjax(typeof(AjaxTest1),this);
        Session["fds"] = DateTime.Now;
        Session["33"] = 00;
        Response.Cookies.Add(new HttpCookie("ss", "222"));
       
    }

    [Ajax.AjaxMethod()]
    public string GetDate()
    {
        return DateTime.Now.ToString();
    }
}
