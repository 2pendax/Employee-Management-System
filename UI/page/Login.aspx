<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>欢迎使用登录员工管理系统！</title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
	body { 
	background:  url(images/bg.png) repeat-x ;  
	
}
  .wrapper{
    width: 690px;
    height: 378px;
    background-image: url(images/login.png);
    margin: 0 auto;
    margin-top: 200px;

  }
  .login{
    width: 250px;
    height: 250px;
   
    float: right;
    margin-top: 70px;
    margin-right: 140px;


  }
.item1{
  margin-top: 40px;


  }
  .item2{
    margin-top: 10px;
  }
.item3{
  float: right;
  margin-top: 10px;
  margin-right: 70px;
}
   
	</style>
</head>

<body>
    <form id="form1" runat="server">
       <div class="wrapper">

      <div class="login">
      <div class="item1">
       用户名<asp:textbox runat="server" ID="txtUserName"></asp:textbox>
       <div>
       <div class="item2">
       密码&nbsp&nbsp&nbsp&nbsp<asp:textbox runat="server" ID="txtPassword" TextMode="Password"></asp:textbox>
     
       <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" />
       <div>
                    <asp:Label ID="lblError" runat="server" Text="" CssClass="redText"></asp:Label>&nbsp
        </div>
    
    </div>
  </div>
		 
     </div>      
    </form>
</body>
</html>

