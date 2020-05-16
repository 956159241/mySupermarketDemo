<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="mySupermarketDemo.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">

//        判断输入是否为空
        function checkUserInfo(){
            if($("#txtUserName").val() == ""){
                alert("请输入用户名");
                return false;
            }
            if($("#txtPassword").val() == ""){
                alert("请输入密码");
                return false;
            }
        }
    </script>
    <style type="text/css" >
       body{background-image:url('Images/SupermarketLogin_bg_pic.jpg');background-size:100% 300%; color:red;text-align:center;}
       .my_login{width:500px;margin:50px auto;text-align:center;background-color:rgba(0,0,0,0.1);} 
       #btnLogin{display: inline-block;outline: none;cursor: pointer;text-align: center;
                    text-decoration: none;font: 14px/100% Arial, Helvetica, sans-serif;padding: .5em 2em .5em;
                    text-shadow: 0 1px 1px rgba(0,0,0,.3);-webkit-border-radius: .5em; -moz-border-radius: .5em;
                    border-radius: 0em;-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);-moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
                    box-shadow: 0 1px 2px rgba(0,0,0,.2);margin-left:80px;}
       
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3 class = "welcome_title">超市管理后台登录</h3>
        <div class="my_login">
            
            <%--登录用户名--%><br/><br/><br/>
            <asp:Label ID="labelUserName" runat="server" Text="用户名："></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br/><br/>
            <%--登录密码--%>
            <asp:Label ID="labelPassword" runat="server" Text="密  码 ："></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br/><br/>
            <%--登录按钮--%>
            <asp:Button ID="btnLogin" runat="server" Text="登录" 
                OnClientClick="return checkUserInfo()" onclick="btnLogin_Click"/>
            <br/><br/><br/>
        </div>
    </form>
</body>
</html>
