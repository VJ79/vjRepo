<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>


    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="ErrorMessage____">Textffff</asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <input type="button" value="test" onclick="simpleSwap()" />
    </form>
    <script type="text/javascript">
<!--
        document.write("Hello \
World!")
        document.write("Hello    \
World!")
        try {
            adddlert("Welcome guest!")
        }
        catch (err) {
            txt = "此页面存在一个错误。\n\n"
            txt += "错误描述: " + err.description + "\n\n"
            txt += "点击OK继续。\n\n"
            alert(txt)
        }

        alert( alert("文本"));
        var b= confirm("confirm");
        var c = alert(prompt("prompt", b));
        alert(c);
        document.write("Hello World!");
        document.write($(document.getElementById("TextBox1")));
        document.write(eval("$(document.getElementById('TextBox1'))"));
        //-->
        function $(obj) {
            return obj.id;
        }

        function simpleSwap() {
            var the_image = prompt("change parrot or cheese", "");
            var the_image_name = "window.document." + the_image;
            var the_image_object = eval(the_image_name);
            the_image_object.src = "ant.gif";
        }
</script>
</body>
</html>
