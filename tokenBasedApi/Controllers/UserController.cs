using BEL;
using BLL;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using tokenBasedApi.Auth;

namespace tokenBasedApi.Controllers
{
   // [Route("api/[controller]")]
    //[ApiController]
    public class UserController : ControllerBase
    {

       
        [Route("api/users")]
        [HttpGet]
        [CustomAuth]
        public ActionResult Get()
        {
            var model = UserService.Get();          
            return Ok(model);
        }
        [Route("api/users/{id}")]
        [HttpGet]
        public ActionResult Get(int id)
        {
            var model = UserService.Get(id);
            return Ok(model);
           
            
            
        }
        [Route("api/users/create")]
        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            UserService.Create(user);
            return Ok();
        }
        [Route("api/users/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(UserModel user)
        {
            UserService.Edit(user);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [Route("api/users/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            UserService.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
            
       
    }
}
