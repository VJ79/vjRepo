<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" EnableViewState="false"  %>

<%@ Register src="WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" type="text/javascript">
        tempCSS = "";
        var i = 0;
        function getRowAndColumn(tableName) {
            if (!document.getElementsByTagName || !document.createTextNode) return;

            tables = document.getElementsByName(tableName);

            for (tableIndex = 0; tableIndex < tables.length; tableIndex++) {
                var rows = tables[tableIndex].getElementsByTagName('tr');

                for (i = 0; i < rows.length; i++) {
                    element1 = rows[i].parentElement;
                    //if (element1.id != tableName)
                    // return;
                    rows[i].onmouseover = function() {
                        tables = document.getElementsByName(tableName);
                        if (this.parentElement.parentElement.id != tableName)
                            return;
                        tempCSS = rows[this.rowIndex].style.backgroundColor;
                        for (j = 0; j < tables.length; j++) {
                            rows_ = tables[j].getElementsByTagName('tr');
                            rows_1 = new Array();
                            row_1Index = 0;
                            for (n = 0; n < rows_.length; n++) {
                                if (rows_[n].parentElement.parentElement.id == tableName) {
                                    rows_1[row_1Index] = rows_[n];
                                    row_1Index++;
                                }
                            }
                            rows_1[this.rowIndex].style.backgroundColor = "yellow";
                        }
                    }
                    rows[i].onmouseout = function() {
                        tables = document.getElementsByName(tableName);
                        if (this.parentElement.parentElement.id != tableName)
                            return;
                        for (j = 0; j < tables.length; j++) {

                            rows_ = tables[j].getElementsByTagName('tr');
                            rows_1 = new Array();
                            row_1Index = 0;
                            for (n = 0; n < rows_.length; n++) {
                                if (rows_[n].parentElement.parentElement.id == tableName) {
                                    rows_1[row_1Index] = rows_[n];
                                    row_1Index++;
                                }
                            }
                            rows_1[this.rowIndex].style.backgroundColor = tempCSS;
                        }
                        tempCSS = "";
                    }

                }
            }
        }

       
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="MyTable">
            <tr>
                <td>
                    1111111111111111111111111
                </td>
            </tr>
            <tr>
                <td>
                    <table id="Table1">
                        <tr id="ff7fff">
                            <td>
                                2222222222222222222222222
                            </td>
                            <tr id="Tr1">
                                <td>
                                    2222222222222222222222222
                                </td>
                            </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    111111111111111111111
                </td>
            </tr>
        </table>
        ---------------------------------------------------------
        <table id="MyTable">
            <tr>
                <td>
                    66666666666666666
                </td>
            </tr>
            <tr>
                <td>
                    66666666666666666
                    <uc1:WebUserControl ID="WebUserControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    66666666666666666
                </td>
            </tr>
        </table>
    </div>
    <button type="button" onclick="getRowAndColumn('MyTable')">
        fds</button>
              <button type="button" onclick="Indddd()">
        dddddddd</button>
    <asp:Button ID="Button1" Enabled="false" runat="server" Text="Button" />
                   
             <input id="Submit1" type="submit" value="submit" />
    <asp:Button ID="Button3" runat="server" Text="Button" />
    </form>
  
 
        
  
</body>


<script language="javascript">
    function Indddd() {
        cellsArray = new Array();
        cellsArray['44'] = "green";

        alert(cellsArray['44']);
        if(cellsArray["df"]==null)
        alert(cellsArray["df"]);
    }
    //    document.getElementsByName("fffff")[0].onmouseover = function() {
    //        alert(this.rowIndex);
    //    }
    //        document.getElementsByName("fffff")[1].onmouseover = function() {
    //        alert(this.rowIndex);
    //    }
   

</script>

</html>
