<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<frameset rows="120px,*,100px">
    <frame name="top" src="top.htm"></frame>
    <frameset cols="200px,*">
        <frame name="left" src="left.aspx"></frame>
        <frame name="right" src="right.htm"></frame>
    </frameset>
   
</frameset>

<body>
</body>
</html>
