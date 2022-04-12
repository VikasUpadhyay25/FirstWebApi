using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstWebApi.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        

        private static string connectionString = @"Data Source=DESKTOP-37UDTFK\VIKASSQL;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing";

        internal static object GetProvider()
        {
            throw new NotImplementedException();
        }

        public static DataSet GetProviderData()
        {

            SqlConnection conn = new SqlConnection(connectionString);


            conn.Open();
            SqlCommand command = new SqlCommand("select * from Provider", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            return ds;
        }

        internal void InsertProvider(Provider p)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"insert into Provider (ProviderName, ProviderType) values ('{p.ProviderName}','{p.ProviderType}')";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal void UpdateProvider(Provider p)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"update provider set providertype='{p.ProviderType}', providername='{p.ProviderName}' where providerid={p.ProviderId}";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal static void DeleteProvider(int p)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"Delete provider where providerid={p}";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        public static DataSet GetProviderDataByProviderId(int id)
        {

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();
            SqlCommand command = new SqlCommand($"select * from Provider where providerid = {id}", conn);
            SqlDataAdapter adaptor = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);
            return ds;
        }              
    }
}