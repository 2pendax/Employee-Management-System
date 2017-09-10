using System;
using System.Collections;
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
using Model;

public partial class page_EMP_AddEmployee : System.Web.UI.Page


{
    EmployeeBLL bll = new EmployeeBLL();
    Employee emp = new Employee();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) //如果是首次加载
        {
            empBirthday.Attributes.Add("onclick", "WdatePicker()");
          
        }

    }

   


    protected void btnAdd_Click(object sender, EventArgs e)
    {

        emp.empName = empName.Text;
        emp.empSex = empSex.Text;
        emp.empBirthday = empBirthday.Text;
        emp.deptId =deptId.Text;
        emp.postId = postId.Text;
        Response.Write("<script>('添加成功！')</script>");

        if (bll.Add(emp) == 1)
        {
            Response.Write("<script>('添加成功！')</script>");
            
        }
        else
        {
            Response.Write("<script>('添加失败！')</script>");
        }  

    }
    
}
