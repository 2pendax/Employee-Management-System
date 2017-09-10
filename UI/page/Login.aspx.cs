using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //1.取得数据
        string userName = txtUserName.Text.Trim();
        string password = txtPassword.Text.Trim();

        //2.进行登录验证
        EmployeeBLL empBLL = new EmployeeBLL();
        bool isSuccess = empBLL.VerifyLogin(userName, password);

        //3.根据验证结果，进行处理（如果成功，跳转到主页面；否则，提示用户名或者密码错误）
        if (isSuccess)
        {
            Response.Redirect("~/page/Main.aspx");
        }
        else 
        {
            lblError.Text = "用户名或者密码错误！";
        }

    }

   
}
