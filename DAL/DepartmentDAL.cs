using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Common;

namespace DAL
{
    public class DepartmentDAL
    {
        /// <summary>
        /// 查询所有的部门。
        /// </summary>
        /// <returns>返回所有部门信息的数据集对象</returns>
        public DataSet QueryDepartmentList() 
        {
            DataSet ds = new DataSet();

            string sql = "select * from Department";
            ds = SQLHelper.ExecuteQuery(sql);

            return ds;
        }
    }
}
