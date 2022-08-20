using BEL;
using BLL;
using Microsoft.AspNetCore.Mvc;


namespace tokenBasedApi.Controllers
{
  
    public class AuthController : ControllerBase
    {
        [Route("api/login")]
        [HttpPost]
        public IActionResult Auth(string name,  string pass)
        {
           
            var data = AuthService.Auth(name,pass);
            
            if (data != null)
            {
               
                HttpContext.Session.SetString("Authorization", data.AccessToken.ToString());
                           
                HttpContext.Response.Headers.Add("Authorization", data.AccessToken.ToString());
                return Ok(data);

            }
            return  null;
        }

        [Route("api/logout")]
        [HttpGet]
        public ActionResult Logout()
        {
            var token = HttpContext.Session.GetString("Authorization");
            if (token != null)
            {
                var rs = AuthService.Logout(token);
                if (rs)
                {
                    return Ok("Sucess fully logged out");
                }

            }
            return BadRequest("Invalid token to logout");
        }
    }
}
