using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{

    public class EmployeeBLL
    {
        EmployeeDAL empdal = new EmployeeDAL();
       
        /// <summary>
        /// 登录验证。如果登录成功，返回true；否则，返回false
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>如果登录成功，返回true；否则，返回false</returns>
        public bool VerifyLogin(string userName, string password) 
        {
            bool isSuccess = false;

            UserInfoDAL userDal = new UserInfoDAL();
            UserInfo user= userDal.QueryUserByUserName(userName);
            if (user.UserName != null && user.UserPwd==password) {
                isSuccess = true;
            }

            return isSuccess;
        }

        public DataSet GetAllDepartment() 
        {
            DepartmentDAL deptDal = new DepartmentDAL();
            return deptDal.QueryDepartmentList();
        }

        /// <summary>
        /// 根据条件查询员工信息，返回查询结果的数据集对象。
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="deptId">部门编号</param>
        /// <param name="beginDate">开始出生日期</param>
        /// <param name="endDate">结束出生日期</param>
        /// <returns></returns>
        public DataSet QueryEmployeeBy(string name, string deptId) 
        {
            return new EmployeeDAL().QueryEmployeeBy(name, deptId);
        }

        public int Add(Employee emp) {

           return empdal.Add(emp);
        
        }
        public int Delete(Employee emp) {

            return empdal.Delete(emp);
        }
        public int Update(Employee emp)
        {

            return empdal.Update(emp);
        }
        public DataTable Select()
        {
            return empdal.Select();
        }  

    }
}
