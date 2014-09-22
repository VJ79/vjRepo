<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <title>GridView无刷新排序</title>
    <link type="text/css" href="GridView.css" rel="stylesheet" />
    <link type="text/css" href="Progress.css" rel="stylesheet" />
    <script runat="server">
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                System.Threading.Thread.Sleep(3000);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gridView = (GridView)sender;

            if (gridView.SortExpression.Length > 0)
            {
                int cellIndex = -1;
                foreach (DataControlField field in gridView.Columns)
                {
                    if (field.SortExpression == gridView.SortExpression)
                    {
                        cellIndex = gridView.Columns.IndexOf(field);
                        break;
                    }
                }

                if (cellIndex > -1)
                {
                    if (e.Row.RowType == DataControlRowType.Header)
                    {
                        //  this is a header row,
                        //  set the sort style
                        e.Row.Cells[cellIndex].CssClass +=
                            (gridView.SortDirection == SortDirection.Ascending
                            ? " sortascheader" : " sortdescheader");
                    }
                    else if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        //  this is an alternating row
                        e.Row.Cells[cellIndex].CssClass +=
                            (e.Row.RowIndex % 2 == 0
                            ? " sortaltrow" : "sortrow");
                    }
                }
            }
        }        
        
    </script>
</head>
<body>
    <form id="form" runat="server">
        <asp:ObjectDataSource ID="odsCustomers" runat="server" SelectMethod="Select" TypeName="CustomersDataObject" />
        <asp:ScriptManager runat="server" />
        <script type="text/javascript">

            function onUpdating(){
                // get the update progress div
                var pnlPopup = $get('<%= this.pnlPopup.ClientID %>'); 

                //  get the gridview element        
                var gridView = $get('<%= this.gvCustomers.ClientID %>');
                
                // make it visible
                pnlPopup.style.display = '';	    
                
                // get the bounds of both the gridview and the progress div
                var gridViewBounds = Sys.UI.DomElement.getBounds(gridView);
                var pnlPopupBounds = Sys.UI.DomElement.getBounds(pnlPopup);
                
                //  center of gridview
                var x = gridViewBounds.x + Math.round(gridViewBounds.width / 2) - Math.round(pnlPopupBounds.width / 2);
                var y = gridViewBounds.y + Math.round(gridViewBounds.height / 2) - Math.round(pnlPopupBounds.height / 2);	    

                //	set the progress element to this position
                Sys.UI.DomElement.setLocation(pnlPopup, x, y);           
            }

            function onUpdated() {
                // get the update progress div
                var pnlPopup = $get('<%= this.pnlPopup.ClientID %>'); 
                // make it invisible
                pnlPopup.style.display = 'none';
            }            
            
        </script>
        <div>
            <p>
            YUI Style Progress Indicator
            </p>
            <br />
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView 
                        ID="gvCustomers" runat="server" CssClass="tablestyle" 
                        AllowSorting="true" DataSourceID="odsCustomers" 
                        OnRowDataBound="GvCustomers_RowDataBound" AutoGenerateColumns="false">
                        <AlternatingRowStyle CssClass="altrowstyle" />
                        <HeaderStyle CssClass="headerstyle" />
                        <RowStyle CssClass="rowstyle" />
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="customerid" SortExpression="customerid" />
                            <asp:BoundField HeaderText="Company" DataField="companyname" SortExpression="companyname" />
                            <asp:BoundField HeaderText="Contact Name" DataField="contactname" SortExpression="contactname" />
                            <asp:BoundField HeaderText="Contact Title" DataField="contacttitle" SortExpression="contacttitle" />
                            <asp:BoundField HeaderText="Country" DataField="country" SortExpression="country" />
                            <asp:BoundField HeaderText="Phone" DataField="phone" SortExpression="phone" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <ajaxToolkit:UpdatePanelAnimationExtender runat="server" TargetControlID="updatePanel">
                <Animations>
                    <OnUpdating>
                        <Parallel duration="0">
                            <%-- place the update progress div over the gridview control --%>
                            <ScriptAction Script="onUpdating();" />  
                         </Parallel>
                    </OnUpdating>
                    <OnUpdated>
                        <Parallel duration="0">
                            <%--find the update progress div and place it over the gridview control--%>
                            <ScriptAction Script="onUpdated();" /> 
                        </Parallel> 
                    </OnUpdated>
                </Animations>
            </ajaxToolkit:UpdatePanelAnimationExtender>            
            <asp:Panel ID="pnlPopup" runat="server" CssClass="progress" style="display:none;">
                <div class="container">
                    <div class="header">Loading, please wait...</div>
                    <div class="body">
                        <img src="img/activity.gif" />
                    </div>
                </div>
            </asp:Panel> 
        </div>
        <a href="http://www.51aspx.com" target="_blank">download from 51aspx.com</a>

    </form>
</body>
</html>
