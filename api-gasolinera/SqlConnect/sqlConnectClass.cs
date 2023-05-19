using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api_gasolinera.SqlConnect
{
    public class sqlConnectClass
    {

        private static string constring = ConfigurationManager.AppSettings["conexionDB"];

        public static DataTable RunSql(string Sql)
        {
            DataTable Dt = new DataTable();
            //try
            //{

            using (SqlConnection Cnn = new SqlConnection(constring))
            {
                SqlCommand Cmd = new SqlCommand(Sql, Cnn);
                Cmd.CommandTimeout = 0;
                Cnn.Open();
                SqlDataReader Reader = Cmd.ExecuteReader();
                Dt.Load(Reader);
                Cmd.Dispose();
                return Dt;
            }
            //}
            //catch (Exception ex)
            //{
            //    constring = String.Empty;
            //}
            //return null;

        }

        public static int ExecuteSql(string Sql)
        {
            int opr = 0;
            //try
            //{

            using (SqlConnection Cnn = new SqlConnection(constring))
            {
                SqlCommand Cmd = new SqlCommand(Sql, Cnn);
                Cmd.CommandTimeout = 0;
                //Cmd.CommandType = CommandType.StoredProcedure;
                Cnn.Open();
                opr = Convert.ToInt32(Cmd.ExecuteNonQuery());
                Cmd.Dispose();
                return opr;
            }
            //}
            //catch (Exception ex)
            //{
            //    constring = String.Empty;
            //}
            //return null;

        }


    }
}