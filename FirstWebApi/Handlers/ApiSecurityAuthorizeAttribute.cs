using FirstWebApi.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FirstWebApi.Handlers
{
    public class ApiSecurityAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            var user = HttpContext.Current.User.Identity.Name;

            ProductDatabaseEntities entity = new ProductDatabaseEntities();

            //var role = entity.Users.Where(x => x.UserName == user).FirstOrDefault().Roles;
            var role = entity.Users.Where(x => x.UserName == user).FirstOrDefault()?.Roles;

           


            var roles = Roles.Split(',');
            
            
            //if (Roles != role)
            if (!Roles.Contains(role))
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage
                    (System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}