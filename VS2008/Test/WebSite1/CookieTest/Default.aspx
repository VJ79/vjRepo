<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="CookieTest_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/Style/style.css" rel="stylesheet" type="text/css" />
    <link href="/skin/black/ymPrompt.css" rel="stylesheet" type="text/css" />

    <script src="Cookie.js" type="text/javascript"></script>
    <script src="../js/AddAndDeleteRow.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <a name="top"></a>
    <table width="100%" height="37" border="0" cellpadding="0" cellspacing="0">
	  <tr>
		<td height="37" valign="top" background="/images/index_03.gif">
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
			  <tr>
				<td width="39" height="37" background="/images/index_05.gif"></td>
				<td id="ho_dz" height="37"  >当前位置：首页&nbsp;&gt;&gt;&nbsp;数据比较列表</td>
				
			  </tr>
		  </table>
		</td>
	  </tr>
	</table>
    <div>
        KEY:
        <input id="inputKey" type="text" />
        ID:
        <input id="inputID" type="text" />
        SupplierGLN:
        <input id="GTIN" type="text" />
    </div>
    <input id="Button1" type="button" value="SetCookie" onclick="return Button1_onclick()" />
    <input id="Button2" type="button" value="GetCookie" onclick="return Button2_onclick()" />
    <input id="Button3" type="button" value="DeleteCookie" onclick="return Button3_onclick()" />
    <input id="Button4"  value="submit" type="button" onclick="SubmitComparision('<%= Address %>')" />
    <input id="Button5" runat="server" value="InsertRow" type="button" onclick="return Button5_onclick()" />
    <div>
    <div>
    
      <div id="dbl">
		<div id="dbl_t"><img src="../Images/db_03.gif" class="img_b" />&nbsp;信息对比栏</div>
		<div id="dbl_c">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ho_c_c_b">
            <tr>
                <td width="8">
                    &nbsp;
                </td>
                <td>
                 <table width="100%" id="TableProductForm" border="0" cellspacing="0" cellpadding="0" class="ho_c_c">
                        <tr>
                            <td colspan="4" class="ho_c_c_t" style="height: 30px">
                                <span style="height: 12px">
                                    <asp:Literal ID="title" runat="server" Text="&nbsp;&nbsp;比较列表"></asp:Literal>
                                </span>
                            </td>
                        </tr>
          
          <%--  <thead class="biaotitle">--%>
                <tr  id="headStyle">
                    <td>
                        序号
                    </td>
                     <td>
                        HistoryItemId
                    </td>
                     <td>
                        GTIN
                    </td>
                    <td>
                        删除
                    </td>
                </tr>
            <%--</thead>       --%>       
        </table>
        </td>
        </tr>
        </table>
        	</div>
		<div id="dbl_b"><input name="button" type="button" value="对&nbsp;比" class="ho_sb" />&nbsp;<input name="button" type="button" value="清&nbsp;空" class="ho_sb" /><input 
                id="Button6" type="button" value="button" onclick="return Button6_onclick()" /></div>
	</div>
    </div>
          <input id="btnCompare" class="ho_b_search" 
            onclick='<% ="SubmitComparision(\""+Request.Url.Authority + "/ItemHistory/Comparision1.aspx\")"%>' 
            type="button" value="进行比较" />
            
          
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
			  <tr>
				<td width="189" class="dbl_c_c"><a href="#">6901234000016</a></td>
				<td width="11" class="dbl_c_c"><img src="../Images/dbl_18.gif" class="img_b" /></td>
			  </tr>
			  <tr>
				<td width="189" class="dbl_c_c"><a href="#">6901234000016</a></td>
				<td width="11" class="dbl_c_c"><img src="images/dbl_18.gif" class="img_b" /></td>
			  </tr>
			  <tr>
				<td width="189" class="dbl_c_c"><a href="#">6901234000016</a></td>
				<td width="11" class="dbl_c_c"><img src="images/dbl_18.gif" class="img_b" /></td>
			  </tr>
			  <tr>
				<td width="189" class="dbl_c_c"><a href="#">6901234000016</a></td>
				<td width="11" class="dbl_c_c"><img src="images/dbl_18.gif" class="img_b" /></td>
			  </tr>
			  <tr>
				<td width="189" class="dbl_c_c"><a href="#">6901234000016</a></td>
				<td width="11" class="dbl_c_c"><img src="images/dbl_18.gif" class="img_b" /></td>
			  </tr>
		  </table>
	
    </form>
</body>

<script language="javascript" type="text/javascript">

    //    inputKey = document.getElementById("inputKey");
    //    inputKey.value="comparisionDataList__"
    inputID = document.getElementById("inputID");
    GTIN = document.getElementById("GTIN");



    function Button5_onclick() {
        // TableProductForm = document.getElementById("TableProductForm");
        InsertRow(TableProductForm);
    }




    function Button1_onclick() {
        if (SetHistoryItemIdentification(inputID.value, GTIN.value)) {
            InsertRow(TableProductForm);
        }
    }


    function Button2_onclick() {
        window.alert(GetComparisionList());
    }

    //    function Button3_onclick() {
    //     
    //        DeleteHistoryItemIdentification( inputID.value, GTIN.value);
    //    }


    function deleteComparision(tableId, historyItemId, gtin) {
        del(tableId);
        DeleteHistoryItemIdentification(historyItemId, gtin);
    }
    InsertRow(TableProductForm);

    function Button6_onclick() {
        //window.showModelessDialog("/Default.aspx", 800, 650)
        window.showModelessDialog("Default.aspx", window, "status:false;dialogWidth:300px;dialogHeight:300px;edge:Raised; enter: Yes; help: No; resizable: No; status: No");
        
        
    }

</script>

</html>
