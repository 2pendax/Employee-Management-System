<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="page_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style ="background-color:#f0f9fd;"> 
    <form id="form1" runat="server">
    <div style ="background-color:#7acafd;">
        <asp:TreeView ID="tvMenu" runat="server" ImageSet="Contacts" NodeIndent="10">
            <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
            <HoverNodeStyle Font-Underline="False" />
            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" 
                VerticalPadding="0px" />
            <Nodes>
                <asp:TreeNode Text="人事管理系统" Value="客户关系管理系统">
                    <asp:TreeNode Text="员工管理" Value="员工管理" 
                        NavigateUrl="~/page/EMP/EmployeeList.aspx" Target="right"></asp:TreeNode>
                    <asp:TreeNode Text="用户管理" Value="用户管理"></asp:TreeNode>
                     <asp:TreeNode Text="技术支持" Value="技术支持" 
                        NavigateUrl="~/page/tech.htm" Target="right"></asp:TreeNode>
                    
                    
                </asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
