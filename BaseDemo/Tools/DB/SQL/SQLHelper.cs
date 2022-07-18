using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tools.DB.SQL {

    public class SQLHelper {
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        /// <summary>
        /// 执行insert、update、delete操作
        /// </summary>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="param">Sql参数</param>
        /// <param name="isProcedure">是否是存储过程</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, SqlParameter[] param = null, bool isProcedure = false) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            try {
                conn.Open();
                if (param != null)
                    cmd.Parameters.AddRange(param);
                if (isProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// 事务方法 执行insert、update、delete操作
        /// </summary>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="param">Sql参数</param>
        /// <param name="isProcedure">是否是存储过程</param>
        /// <returns></returns>
        public static bool ExecuteNonQueryByTran(Dictionary<string, SqlParameter[]> dicParam) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();//【1】开启事务
                foreach (var sql in dicParam.Keys) {
                    cmd.CommandText = sql;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(dicParam[sql]);
                    cmd.ExecuteNonQuery();
                }
                cmd.Transaction.Commit();//【2】提交事务
                return true;
            } catch (Exception ex) {
                if (cmd.Transaction != null) {
                    cmd.Transaction.Rollback();//【3】回滚事务
                }
                throw ex;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行单一结果查询
        /// </summary>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="param">Sql参数</param>
        /// <param name="isProcedure">是否是存储过程</param>
        /// <returns></returns>
        public static object ExecuteScalar(string cmdText, SqlParameter[] param = null, bool isProcedure = false) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            try {
                conn.Open();
                if (param != null)
                    cmd.Parameters.AddRange(param);
                if (isProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteScalar();
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行select操作
        /// </summary>
        /// <param name="cmdText">Sql语句</param>
        /// <param name="param">Sql参数</param>
        /// <param name="isProcedure">是否是存储过程</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string cmdText, SqlParameter[] param = null, bool isProcedure = false) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            try {
                conn.Open();
                if (param != null)
                    cmd.Parameters.AddRange(param);
                if (isProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// 执行select操作
        /// </summary>
        /// <param name="dicSql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(Dictionary<string, string> dicSql) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try {
                conn.Open();
                foreach (var key in dicSql.Keys) {
                    cmd.CommandText = dicSql[key];
                    da.Fill(ds, key);
                }
                return ds;
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行select操作
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string cmdText) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try {
                conn.Open();
                da.Fill(ds);
                return ds;
            } catch (Exception ex) {
                throw ex;
            } finally {
                conn.Close();
            }
        }
    }
}