<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxTest1.aspx.cs" Inherits="AjaxTest1"  %>

<%@ Register src="AjaxTest.ascx" tagname="AjaxTest" tagprefix="uc1" %>

<%@ Register src="testaaa.ascx" tagname="testaaa" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript">
        function test() {
            response1 = AjaxTest1.GetDate();
            document.getElementById("llll").innerText = response1.value;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
    
        <uc2:testaaa ID="testaaa1" runat="server" />
    
       
    
    </div>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="llll" Text="fdsat" runat="server"></asp:Label>
    </form>
</body>
</html>
