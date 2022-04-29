using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Handlers;
using FirstWebApi.Models;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace FirstWebApi.Controllers
{
    //public class ProviderController : ApiController
    //{
    //public List<Provider> GetProviders()
    //{
    //    List<Provider> p = new List<Provider>();

    //    var dataTables = Provider.GetProviderData();

    //    foreach (DataRow data in dataTables.Tables[0].Rows)
    //    {

    //        p.Add(new Provider()
    //        {
    //            ProviderId = Convert.ToInt32(data[0].ToString()),
    //            ProviderName = data[1].ToString(),
    //            ProviderType = data[2].ToString()
    //        });
    //    }

    //    return p;
    //}



    public class ProviderController : ApiController
    {
        
        //[Authorize(Users = "ABC")]
        [ApiSecurityAuthorize(Roles = "user,admin")]
        public List<ProviderModels> GetProviders()
        {
            return ProviderModels.GetProviderData();
        }


        [ApiSecurityAuthorize(Roles = "user,admin")]
        public ProviderModels GetProviderById(int id)
        {
            return ProviderModels.GetProviderDataByProviderId(id);
        }

        //[HttpPost]
        //public void AddProvider(Object p)
        //{
        //    var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString()); 

        //    Provider.InsertProvider(provider);
        //}


        [HttpPost]
        [ApiSecurityAuthorize(Roles = "user,admin")]
        public void AddProvider([FromBody] ProviderModels p)
        {
            //var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString());

            ProviderModels.InsertProvider(p);
        }

        //[HttpPost]
        //public void AddProvider([FromBody] Provider p)
        //{
        //    //var provider = Newtonsoft.Json.JsonConvert.DeserializeObject<Provider>(p.ToString());

        //    Provider.InsertProvider(p);
        //}

        [HttpPatch]
        [ApiSecurityAuthorize(Roles = "admin")]
        public void UpdateProvider([FromBody] ProviderModels P)
        {
            ProviderModels.UpdateProvider(P);
        }

        [HttpDelete]
        [ApiSecurityAuthorize(Roles = "admin")]
        public void DeleteProvider(int id)
        {
            ProviderModels.DeleteProvider(id);
        }

    }
}
