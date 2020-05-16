<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersManage.aspx.cs" Inherits="mySupermarketDemo.UsersManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script  language="javascript" type="text/javascript">
        $(function () {
            $("#btnAdd").click(function () { //点击事件
                var name = $("#txtName").val();
                var password = $("#txtPassword").val();
                $.ajax({
                    url: "UsersManageHandler.ashx",
                    type: "POST",
                    data: { name: name, password: password },
                    success: function (data) {
                        if (data != '') {
                            alert(data);
                        } else {
                            location.reload();
                        }
                    }

                }

                );
            });
        });
        
    </script>

     <style type="text/css">
        body{background-image:url('Images/mybg.jpg');background-size:100% auto;text-align:center;}
        .my_content{width:500px;margin:100px auto;}
        #btnDelete,#btnAdd{display: inline-block;outline: none;cursor: pointer;text-align: center;
	                        text-decoration: none;font: 14px/100% Arial, Helvetica, sans-serif;padding: .1em 1em .1em;
	                        text-shadow: 0 1px 1px rgba(0,0,0,.3);-webkit-border-radius: .5em; -moz-border-radius: .5em;
	                        border-radius: 0em;-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);-moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
	                        box-shadow: 0 1px 2px rgba(0,0,0,.2);}
	    tr>td:nth-child(2){width:110px;padding-left:20px;}
	    #txtName,#txtPassword{width:120px;}
	    #btnDelete{margin-left:0px;}
	    #btnAdd{margin-left:230px;}
    
    </style>
</head>
<body>
     <form id="form1" runat="server">
    <div class="my_content">
        
        <asp:Label ID="Label1" runat="server" Text="用户名称"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br/><br/>
        <asp:Button ID="btnDelete" runat="server" Text="删除" onclick="btnDelete_Click"/>
        <asp:Button ID="btnAdd" runat="server" Text="新增" /><br/><br/>

       

    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" style="width:400px;margin:10px auto;">
        <Columns>
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBoxSel" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UserName" HeaderText="用户名" />
            <asp:BoundField DataField="Password" HeaderText="密码" />
        </Columns>
    </asp:GridView>
           </div> 
    </form>
</body>
</html>

