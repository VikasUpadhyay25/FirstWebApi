using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FirstWebApi.DataObject;

namespace FirstWebApi.Models
{
    public class ProviderModels
    {
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderType { get; set; }
        public static object AutoMapperConfig { get; private set; }

        private static string connectionString = @"Data Source=DESKTOP-37UDTFK\VIKASSQL;Initial Catalog=ProductDatabase;User ID=mvcdev;Password=testing";

        public static List<ProviderModels> GetProviderData()
        {
            List<ProviderModels> p = new List<ProviderModels>();


            //SqlConnection conn = new SqlConnection(connectionString);

            //conn.Open();
            //SqlCommand command = new SqlCommand("select * from Provider", conn);
            //SqlDataAdapter adaptor = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();


            //adaptor.Fill(ds);

            //foreach (DataRow data in ds.Tables[0].Rows)
            //{
            //    p.Add(new ProviderModels()
            //    {
            //        ProviderId = Convert.ToInt32(data[0].ToString()),
            //        ProviderName = data[1].ToString(),
            //        ProviderType = data[2].ToString()
            //    });
            //}

            ProductDatabaseEntities entity = new ProductDatabaseEntities();
            var result = entity.Providers.ToList();

            foreach (var data in result)
            {
                p.Add(new ProviderModels()
                {
                    ProviderId = Convert.ToInt32(data.ProviderId),
                    ProviderName = data.ToString(),
                    ProviderType = data.ToString()
                });
            }

            return p;
        }

        public static ProviderModels GetProviderDataByProviderId(int id)
        {
            //List<ProviderModels> p = new List<ProviderModels>();
            //SqlConnection conn = new SqlConnection(connectionString);

            //conn.Open();
            //SqlCommand command = new SqlCommand($"select * from Provider where providerid = {id}", conn);
            //SqlDataAdapter adaptor = new SqlDataAdapter(command);
            //DataSet ds = new DataSet();
            //adaptor.Fill(ds);

            //foreach (DataRow data in ds.Tables[0].Rows)
            //{
            //    p.Add(new ProviderModels()
            //    {
            //        ProviderId = Convert.ToInt32(data[0].ToString()),
            //        ProviderName = data[1].ToString(),
            //        ProviderType = data[2].ToString()
            //    });
            //}

            //return p.FirstOrDefault();

            ProviderModels p = new ProviderModels();

            ProductDatabaseEntities entity = new ProductDatabaseEntities();
            var result = entity.Providers.Where(pr => pr.ProviderId == id).FirstOrDefault();

            var mapper = AutoMapperConfig.AutoMapperConfiguration();
            mapper.Map(result, p);

            return p;
        }

        internal static void InsertProvider(ProviderModels p)
        {
            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"insert into Provider (ProviderName, ProviderType) values ('{p.ProviderName}','{p.ProviderType}')";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();


            Provider newProvider = new Provider();
            var mapper = AutoMapperConfig.AutoMapperConfiguration();
            mapper.Map(p, newProvider);

            newProvider = new Provider()
            {
                ProviderName = p.ProviderName

            };


            ProductDatabaseEntities entity = new ProductDatabaseEntities();
            entity.Providers.Add(newProvider);
            entity.SaveChanges();

        }

        internal static void UpdateProvider(ProviderModels p)
        {
            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"update provider set providertype='{p.ProviderType}', providername='{p.ProviderName}' where providerid={p.ProviderId}";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();

            ProductDatabaseEntities entity = new ProductDatabaseEntities();
            var providerToBeUpdated = entity.Providers.Where(pr => pr.ProviderId == p.ProviderId).FirstOrDefault();

            providerToBeUpdated.ProviderName = p.ProviderName;
            providerToBeUpdated.ProviderType = p.ProviderType;

            entity.SaveChanges();
        }

        internal static void DeleteProvider(int p)
        {
            //SqlConnection conn = new SqlConnection(connectionString);

            //string insertCmd = $"Delete provider where providerid={p}";
            //conn.Open();
            //SqlCommand command = new SqlCommand(insertCmd, conn);
            //command.ExecuteNonQuery();

            ProductDatabaseEntities entity = new ProductDatabaseEntities();
            var providerToBeDeleted = entity.Providers.Where(pr => pr.ProviderId == p).FirstOrDefault();
            entity.Providers.Remove(providerToBeDeleted);
            entity.SaveChanges();
        }
    }
}