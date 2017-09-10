<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="page_EMP_EmployeeList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>员工信息列表</title>
    <style type="text/css">
        .style1
        {
            width: 152px;
        }
        .style2
        {
            width: 131px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="ltr">
        <h2>员工信息列表</h2>
        <table style="width: 730px">
            <tbody>
                <tr>
                    <td class="style2">姓名</td>
                    <td class="style1"> 
                        <asp:TextBox ID="txtName" runat="server"  Width="150px"></asp:TextBox>
                    </td>
                    <td>部门</td>
                    <td> 
                        <asp:DropDownList ID="ddlDepartment" runat="server" Height="16px"  Width="155px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btnAdd" runat="server" Text="新增" onclick="btnAdd_Click" />
                    </td>
                </tr>
                
                 <tr>
                 
                    <td>
                        
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:GridView ID="gvEmployeeList" OnPageIndexChanging="gvEmployeeList_PageIndexChanging" runat="server" AutoGenerateColumns="False" 
            Width="729px" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowdeleting="gvEmployeeList_RowDeleting" 
            onrowcancelingedit="gvEmployeeList_RowCancelingEdit" 
            onrowediting="gvEmployeeList_RowEditing" 
            onrowupdating="gvEmployeeList_RowUpdating" AllowPaging="True">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField HeaderText="编号">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("empId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="姓名">
                    <EditItemTemplate>
                        <asp:TextBox ID="empName" runat="server" Text='<%# Bind("empName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("empName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="性别">
                    <EditItemTemplate>
                        <asp:TextBox ID="empSex" runat="server" Text='<%# Bind("empSex") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("empSex") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="出生日期">
                    <EditItemTemplate>
                        <asp:TextBox ID="empBirthday" runat="server" Text='<%# Bind("empBirthday") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" 
                            Text='<%# Bind("empBirthday", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="所属部门">
                    <EditItemTemplate>
                        <asp:TextBox ID="deptName" runat="server" Text='<%# Bind("deptName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="deptName" runat="server" Text='<%# Bind("deptName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="职务">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("postName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("postName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="更新" />
                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="取消" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                            CommandName="Edit" ImageUrl="~/page/images/bt_edit.gif" Text="编辑" />
                        &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" 
                            CommandName="Delete" ImageUrl="~/page/images/bt_del.gif" Text="删除" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
    </div>
    </form>
</body>
</html>
