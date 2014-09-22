using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(Server.GetLastError());

        //using (ClassLibrary1.D d = new ClassLibrary1.D())
        //{
        //    string ss = "fds";
        //}
        //ClassLibrary1.C c = new ClassLibrary1.C();
        //c.Dispose();
     
    }
 
}
