using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Common
{
    public class SQLHelper
    {
        public static String GetSqlConnection()
        {
            String conn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            return conn;
        }
        /// <summary>
        /// 执行查询sql语句，并返回查询结果的数据集对象。
        /// </summary>
        /// <param name="sql">查询sql语句</param>
        /// <returns>返回查询结果的数据集对象。</returns>
        public static DataSet ExecuteQuery(string sql)
        {

            DataSet ds = new DataSet();
            String ConnStr = SQLHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);

                return ds;
            }
        }

        /// <summary>  
        /// 执行不带参数的查询语句  
        /// </summary>  
        /// <param name="cmdText"></param>  
        /// <param name="Paras"></param>  
        /// <returns></returns>  
        public DataTable ExecSelect(string cmdText, CommandType Cmdtype)
        {
            String ConnStr = SQLHelper.GetSqlConnection();
            SqlConnection con = new SqlConnection(ConnStr);
           
            con.Open();

            //对SqlCommand对象进行实例化  
            SqlCommand SqlComm = new SqlCommand(cmdText, con);
            SqlComm.CommandType = Cmdtype;
            //给参数赋值  
            SqlComm.CommandTimeout = 10000;

            //返回DataReader对象  
            SqlDataReader DataReader = SqlComm.ExecuteReader();
            DataTable Dt = new DataTable();
            //返回DataTable对象  
            Dt.Load(DataReader);

            //返回数据表  
            con.Close();
            return Dt;
        }  

        /// <summary>
        /// 执行增删改sql语句，并返回受影响的行数。
        /// </summary>
        /// <param name="sql">增删改sql语句</param>
        /// <returns>返回受影响的行数。</returns>
        public static int ExecuteNonQuery(string sql)
        {
            int rowCount = 0;
            String ConnStr = SQLHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                rowCount = cmd.ExecuteNonQuery();
            }

            return rowCount;
        }




        /// <summary>
        /// 获得参数对象
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="paramSize">长度</param>
        /// <param name="ColName">源列名称</param>
        /// <returns></returns>
       
        public static SqlParameter GetParameter(String paramName, SqlDbType paramType, Object paramValue)
        {
            SqlParameter param = new SqlParameter(paramName, paramType);
            param.Value = paramValue;
            return param;
        }


        /// <summary>
        /// 执行带参SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象数组</param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr, SqlParameter[] param)
        {
            String ConnStr = SQLHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                cmd.Parameters.AddRange(param);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }

         /// <summary>
        /// 执行无参SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static int ExecuteSql(String Sqlstr)
        {
            String ConnStr = SQLHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return 1;
            }
        }
       
        /// <summary>
        /// 执行无参SQL语句并返回数据表
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr)
        {
            String ConnStr = SQLHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        /// 执行带参SQL语句并返回数据表
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象列表</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr, SqlParameter[] param)
        {
            String ConnStr = SQLHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(Sqlstr, conn);
                cmd.Connection = conn;
                cmd.Parameters.AddRange(param);
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        /// 批量执行带参SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句数组</param>
        /// <param name="param">SQL参数对象数组</param>
        /// <returns></returns>
        public static Int32 ExecuteSqls(String[] Sqlstr, List<SqlParameter[]> param)
        {
            String ConnStr = SQLHelper.GetSqlConnection();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                SqlTransaction tran = null;
                cmd.Transaction = tran;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    Int32 count = Sqlstr.Length;
                    for (Int32 i = 0; i < count; i++)
                    {
                        cmd.CommandText = Sqlstr[i];
                        cmd.Parameters.AddRange(param[i]);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return 1;
                }
                catch
                {
                    tran.Rollback();
                    return 0;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

    }
}
