using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Dapper_Project.Models
{
    public static class DapperORM
    {
        private static string connectionString = "Data Source=LAPTOP-G1JUNNPQ\\SQLEXPRESS;Initial Catalog=myStore;Integrated Security=True";
        public static void ExecuteWithoutReturn(string procedurName, DynamicParameters param=null)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(procedurName, param, commandType: CommandType.StoredProcedure);
            }
        }
        //DapperORM.ExecuteWithReturn<int>(_,_)
        public static T ExecuteWithReturn<T>(string procedurName, DynamicParameters param=null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                 return (T)Convert.ChangeType(conn.ExecuteScalar(procedurName, param, commandType: CommandType.StoredProcedure),typeof(T));
            }
        }
        //DapperORM.ReturnList<ProductModel> <= IEnumerable<ProductModel>
        public static IEnumerable<T> ReturnList<T>(string procedurName, DynamicParameters param=null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<T>(procedurName, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}