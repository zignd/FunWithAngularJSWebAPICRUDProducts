using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FunWithAngularJSWebAPICRUDProducts.Models;
using System.Threading.Tasks;

namespace FunWithAngularJSWebAPICRUDProducts.Controllers
{
    public class UsersController : ApiController
    {
        private UserManager<IdentityUser> UserManager { get; set; }

        public UsersController()
        {
            UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new StoreContext()));
        }

        public IHttpActionResult Get()
        {
            return Ok(UserManager.Users.ToArray());
        }

        public async Task<IHttpActionResult> Post([FromBody]UserViewModel model)
        {
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);

            return Ok();
        }
    }
}
