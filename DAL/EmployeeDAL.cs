using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;
using Model;
using System.Data.SqlClient; //sqlparameter

namespace DAL
{
    public class EmployeeDAL
    {
        SQLHelper Helper = new SQLHelper();
        /// <summary>
        /// 根据条件查询员工信息，返回查询结果的数据集对象。
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="deptId">部门编号</param>
        
        /// <returns></returns>
        public DataSet QueryEmployeeBy(string name, string deptId)
        {
            string sql = "select * from Employee a,Department b,Position c where a.deptId=b.deptId and a.postId=c.postId ";
            if (!string.IsNullOrEmpty(name))
            {
                sql = sql + string.Format(" and a.empname like '%{0}%'", name);
            }
            if (!string.IsNullOrEmpty(deptId) && deptId != "000")
            {
                sql = sql + string.Format(" and a.deptId = '{0}'", deptId);
            }
           
            return SQLHelper.ExecuteQuery(sql);
        }



        public int Add(Employee emp)
        {   
  ///('xp', '男','2/1/1989','1')
            string str = "INSERT INTO Employee  (empName, empSex,empBirthday,deptId,postId) VALUES  (@empName,@empSex,@empBirthday,@deptId,@postId)";
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@empName", emp.empName);
            param[1] = new SqlParameter("@empSex", emp.empSex);
            param[2] = new SqlParameter("@empBirthday", emp.empBirthday);
            param[3] = new SqlParameter("@deptId", emp.deptId);
            param[4] = new SqlParameter("@postId", emp.postId);
            return SQLHelper.ExecuteSql(str, param);

        }



        public int Delete(Employee emp)
        {
            ///('xp', '男','2/1/1989','1')
            string str = "delete from Employee where empId =@empId";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@empId", emp.empId);
          
            
            return SQLHelper.ExecuteSql(str, param);

        }

        public int Update(Employee emp)
        {
            ///('xp', '男','2/1/1989','1')
            string str = "update Employee set empName=@empName,empSex=@empSex,empBirthday=@empBirthday where empId =@empId";
            SqlParameter[] param = new SqlParameter[4];
           // param[0] = new SqlParameter("@empId", emp.empId);
            param[0] = new SqlParameter("@empName", emp.empName);
            param[1] = new SqlParameter("@empSex", emp.empSex);
            param[2] = new SqlParameter("@empBirthday", emp.empBirthday);
            param[3] = new SqlParameter("@empId",emp.empId);
            return SQLHelper.ExecuteSql(str, param);

        }

        public DataTable Select()
        {                               
            //这里需要写两个表联合查询
            string cmdText = "SELECT empId, empName, empSex, empBirthday,deptName,postName FROM   Employee ,Department,Positionwhere   Employee.deptId = Department.deptId ANDDepartment.deptId=Position.deptId";

            return Helper.ExecSelect(cmdText, CommandType.Text);

            
        }  


    }
}