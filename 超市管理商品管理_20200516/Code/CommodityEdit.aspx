<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommodityEdit.aspx.cs" Inherits="mySupermarketDemo.CommodityEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#cbIsDiscount").change(function () {

                isDiscount();
            });
            isDiscount();
        });
        function isDiscount() {
            if ($("#cbIsDiscount").is(":checked")) {
                $("#txtDisPrice").attr("disabled", false);
            } else {
                $("#txtDisPrice").attr("disabled", true);
                $("#txtDisPrice").val("");
            }
        }
    </script>
    <style type="text/css">
        body{background-image:url('Images/mybg.jpg');background-size:100% auto;text-align:center;}
        .my_content{width:600px;margin:50px auto;background-color:rgba(0,0,0,0.05); border-radius:2%;padding:20px;}
        .my_footer{padding-left:50px;}
        .my_footer>input{display: inline-block;outline: none;cursor: pointer;text-align: center;
	                    text-decoration: none;font: 14px/100% Arial, Helvetica, sans-serif;padding: .2em 1em .2em;
	                    text-shadow: 0 1px 1px rgba(0,0,0,.3);-webkit-border-radius: .5em; -moz-border-radius: .5em;
	                    border-radius: 0em;-webkit-box-shadow: 0 1px 2px rgba(0,0,0,.2);-moz-box-shadow: 0 1px 2px rgba(0,0,0,.2);
	                    box-shadow: 0 1px 2px rgba(0,0,0,.2);}
	    #DropDownListEvent{width:153px;heigth:22px;}
	    #txtDisPrice:disabled{background-color:Yellow;}
        
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <h3>商品编辑页面</h3>
    <div class="my_content">
     <asp:Label ID="Label1" runat="server" Text="商品名称"></asp:Label>
     <asp:TextBox ID="txtCName" runat="server"></asp:TextBox><br/><br/>
    
        <asp:Label ID="Label2" runat="server" Text="商品分类"></asp:Label>
        <asp:DropDownList ID="ddlSort" runat="server" style="width:150px;">
        </asp:DropDownList><br/><br/>
    
      
    

    <asp:Label ID="Label3" runat="server" Text="价  格 ： " style="margin-left:105px;"></asp:Label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="是否打折"></asp:Label>
    <asp:CheckBox ID="cbIsDiscount" runat="server" TextAlign="Left"/>
   
    <br/><br />    
    <asp:Label ID="Label5" runat="server" Text="打折价格"></asp:Label>
    <asp:TextBox ID="txtDisPrice" runat="server" disabled = "disabled"></asp:TextBox>
   <br/><br/>
   <div class="my_footer">
    <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click"/>
    <asp:Button ID="btnClose" runat="server" Text="关闭" onclick="btnClose_Click" />
    </div>
        </div>
</form>
</body>
</html>
