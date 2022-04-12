using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    public class ProviderController : ApiController
    {
        public List<Provider> GetProviders()
        {
            List<Provider> p = new List<Provider>();

            var dataTables = Provider.GetProviderData();

            foreach (DataRow data in dataTables.Tables[0].Rows)
            {

                p.Add(new Provider()
                {
                    ProviderId = Convert.ToInt32(data[0].ToString()),
                    ProviderName = data[1].ToString(),
                    ProviderType = data[2].ToString()
                });
            }

            return p;
        }
    }
}
