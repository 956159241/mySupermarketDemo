<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommodityManage.aspx.cs" Inherits="mySupermarketDemo.CommodityManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function newWindow() {
            window.open("CommodityEdit.aspx","编辑页面");
        }
    </script>
    <style type="text/css">
        body{background-image:url('Images/mybg.jpg');background-size:100% auto;text-align:center;}
        .my_content{width:600px;margin:50px auto;background-color:rgba(0,0,0,0.05); border-radius:5%;padding:20px;}
        #gvCommodity{width:450px;margin:10px auto;}
        #btnSearch,#btnDelete,#btnAdd{display: inline-block;outline: none;cursor: pointer;text-align: center;
                    text-decoration: none;font: 14px/100% Arial, Helvetica, sans-serif;padding: .1em 0.5em .1em;
                    text-shadow: 0 1px 1px rgba(0,0,0,.3);-webkit-border-radius: .5em; -moz-border-radius: .5em;
                    border-radius: 0em;-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);-moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
                    box-shadow: 0 1px 2px rgba(0,0,0,.2);}
       #hlCMPage,#hlUMPage{font-size:20px;font-weight:800;text-decoration:none;cursor:pointer;transition:color 1s;}
       #hlCMPage:hover,#hlUMPage:hover{color:white;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="my_content">
    <%--顶部的两个链接--%>
        <asp:HyperLink ID="hlCMPage" runat="server" NavigateUrl = "~/CommoditySortManage.aspx">商品管理界面</asp:HyperLink>
        <asp:HyperLink ID="hlUMPage" runat="server" NavigateUrl="~/UsersManage.aspx">用户管理界面</asp:HyperLink><br/><br/>
        <asp:Label ID="Label1" runat="server" Text="商品分类"></asp:Label>
        <asp:DropDownList ID="ddlSort" runat="server"></asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="商品名称"></asp:Label>
        <asp:TextBox ID="txtCName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="检索" onclick="btnSearch_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="删除" onclick="btnDelete_Click" />
        <asp:Button ID="btnAdd" runat="server" Text="新增" OnClientClick="return newWindow()"/>
        <%--gridview数据展示--%>
        <asp:GridView ID="gvCommodity" runat="server" AutoGenerateColumns="False" DataKeyNames="CommodityID">
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSelection" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品名称">
                    <ItemTemplate>
                        <a target="_blank" href='CommodityEdit.aspx?cid=<%# Eval("CommodityID") %>'>
                            <%#Eval("CommodityName") %>
                        </a>
                        <%--<asp:HyperLink ID="Commodity" runat="server"  
                             NavigateUrl='<%#"CommodityEdit.aspx?cid="+DataBinder.Eval(Container.DataItem,"CommodityID")%> '>
                            <%# Eval("CommodityName") %>
                        </asp:HyperLink>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SortName" HeaderText="类别名称" />
                <asp:BoundField DataField="CommodityPrice" HeaderText="价格" />
                <asp:CheckBoxField DataField="IsDiscount" HeaderText="是否打折" ReadOnly="True" />
                <asp:BoundField HeaderText="打折价格" DataField="ReducedPrice" />
            </Columns>
        </asp:GridView>
        
    </div>
    </form>
    
</body>
</html>
