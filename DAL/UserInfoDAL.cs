using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Model;
using Common;

namespace DAL
{
    /// <summary>
    /// 用户信息数据访问类。主要包括对UserINFO表的增删改查。
    /// </summary>
    public class UserInfoDAL
    {
        /// <summary>
        /// 根据用户名查询对应的用户信息，返回包含对应用户信息的用户对象。
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>如果该用户名对应的用户信息存在，返回包含对应用户信息的用户对象；否则，返回一个空（所有属性都为默认值）的用户对象</returns>
        public UserInfo QueryUserByUserName(string userName) 
        {
            UserInfo user = new UserInfo();

            string sql = string.Format( "select * from userInfo where userName='{0}'",userName);
            DataSet ds = SQLHelper.ExecuteQuery(sql);
            if (ds.Tables[0].Rows.Count > 0) 
            {
                DataRow row = ds.Tables[0].Rows[0];

                user.UserId = Convert.ToInt32(row["userId"].ToString());
                user.UserName = row["userName"].ToString();
                user.UserPwd = row["userPwd"].ToString();
            }

            return user;
        }
    }
}
