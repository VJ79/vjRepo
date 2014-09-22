<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs"
    Inherits="WebUserControl" %>
<p>
    <input id="Text2" enableviewstate="true"  type="text" runat="server" />
    <input id="Text1" enableviewstate="true" disabled="disabled" readonly="readonly" type="text" runat="server" /><input id="Button2"
        type="button" value="button" onclick="return Button2_onclick()" /></p>

<script language="javascript">
    function Button2_onclick() {
        Text2 = document.getElementById("WebUserControl1_Text2");
        Text1 = document.getElementById("WebUserControl1_Text1");
        Text1.value = Text2.value
    }

</script>

