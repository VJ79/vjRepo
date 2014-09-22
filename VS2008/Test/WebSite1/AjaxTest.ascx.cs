using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AjaxTest : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.Attributes.Add("onchange", "test()");
        Ajax.Utility.RegisterTypeForAjax(typeof(AjaxTest));
    }

    [Ajax.AjaxMethod()]
    public string GetDate()
    {
        return DateTime.Now.ToString();
    }
}
