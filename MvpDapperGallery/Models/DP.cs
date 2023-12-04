using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;  //iki satırı ben yazzdım.
using System.Data.SqlClient;
using System.Data;

namespace MvpDapperGallery.Models
{
    public class DP
    {
        public static string connectionString = @"Server=.;Database=DapperGallery;Integrated Security=true;";
        public static void ExecuteReturn(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                db.Execute(procadi, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public static IEnumerable<T> Listeleme<T>(string procadi, DynamicParameters param = null)
        {  //IEnumerable degerleri tek tek döndürür.
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                return db.Query<T>(procadi, param, commandType: CommandType.StoredProcedure);

            }
        }

    }
}