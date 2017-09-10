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

public partial class page_EMP_EmployeeList : System.Web.UI.Page

{

    EmployeeBLL bll = new EmployeeBLL(); //BLL层类的实例化
    Employee emp = new Employee();// model层的实例化
    protected void Page_Load(object sender, EventArgs e)

    {
        if (!IsPostBack) 
        {
            //1.显示部门列表
            ShowDepartmentList();
        }
    }

    private void ShowDepartmentList() 
    { 
        //1.查询数据库
        EmployeeBLL empBll = new EmployeeBLL();
        DataSet ds= empBll.GetAllDepartment();
        //2.绑定到下拉列表
        ddlDepartment.DataTextField = "deptName";
        ddlDepartment.DataValueField = "deptId";
        ddlDepartment.DataSource = ds.Tables[0];
        //ddlDepartment.DataSource = new EmployeeBLL().GetAllDepartment().Tables[0];
        ddlDepartment.DataBind();
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        //1.取得数据
        string name = txtName.Text.Trim();
        string deptId = ddlDepartment.SelectedValue;
       
        //2.查询数据库
        DataSet ds = new EmployeeBLL().QueryEmployeeBy(name, deptId);
        gvEmployeeList.DataSource = ds.Tables[0];
        gvEmployeeList.DataBind();

    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddEmployee.aspx");
    }


    /// <summary>
    /// delete一条信息从表中
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>




    protected void gvEmployeeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        emp.empId = Convert.ToInt32(((gvEmployeeList.Rows[e.RowIndex].FindControl("Label1") as Label).Text));
        Response.Write("<script>('删除成功！')</script>");
        if (bll.Delete(emp) == 1)
        {
            Response.Write("<script>('删除成功！')</script>");
         

        }
        else
        {
            Response.Write("<script>('删除失败！')</script>");
        }  
    }





    protected void gvEmployeeList_RowEditing(object sender, GridViewEditEventArgs e)
    {

        gvEmployeeList.EditIndex = e.NewEditIndex;  

    }
    protected void gvEmployeeList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvEmployeeList.EditIndex = -1;
      



    }

    protected void gvEmployeeList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        emp.empId = Convert.ToInt32(((gvEmployeeList.Rows[e.RowIndex].FindControl("Label1") as Label).Text));
        emp.empName = (gvEmployeeList.Rows[e.RowIndex].FindControl("empName") as TextBox).Text;
        emp.empSex = (gvEmployeeList.Rows[e.RowIndex].FindControl("empSex") as TextBox).Text;
        emp.empBirthday = (gvEmployeeList.Rows[e.RowIndex].FindControl("empBirthday") as TextBox).Text;

        if (bll.Update(emp)==1)
        {
            Response.Write("<script>('修改成功！')</script>");
            gvEmployeeList.EditIndex = -1;
           
        }
        else
        {
            Response.Write("<script>('修改失败！')</script>");
        }  


    }



    protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeList.PageIndex = e.NewPageIndex;
        //1.取得数据
        string name = txtName.Text.Trim();
        string deptId = ddlDepartment.SelectedValue;

        //2.查询数据库
        DataSet ds = new EmployeeBLL().QueryEmployeeBy(name, deptId);
        gvEmployeeList.DataSource = ds.Tables[0];
        gvEmployeeList.DataBind(); //重新绑定GridView数据的函数
    }

    
}
