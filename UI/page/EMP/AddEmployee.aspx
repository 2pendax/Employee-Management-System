<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="page_EMP_AddEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                    姓名
                </td>
                <td>
                    <asp:TextBox ID="empName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    性别
                </td>
                <td>
                    <asp:RadioButtonList ID="empSex" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    出生日期
                </td>
                <td>
                    <asp:TextBox ID="empBirthday" runat="server"></asp:TextBox>
                </td>
              
            </tr>
            <tr>
                <td>
                    所属部门
                </td>
                <td>
                    <asp:TextBox ID="deptId" runat="server"></asp:TextBox>
                    </td>
            </tr>
                 <tr>
                <td>
                    职位
                </td>
                <td>
                    <asp:TextBox ID="postId" runat="server"></asp:TextBox>
                    </td>
            </tr>
             <tr>
                <td class="style1">
                </td>
                <td class="style1">
                    </td>
                <td class="style1">
                    &nbsp;
                </td>
            </tr>
            
             <tr>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="添加" onclick="btnAdd_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
