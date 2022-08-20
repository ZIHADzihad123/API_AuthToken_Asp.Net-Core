using BEL;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace tokenBasedApi.Controllers
{

    public class BlogController : ControllerBase
    {
        [Route("api/blogs")]
        [HttpGet]
        public IActionResult Get()
        {
          
            
            return Ok(BlogsService.Get());
        }
        [Route("api/blogs/{id}")]
        [HttpGet]
        public BlogModel Get(int id)
        {
            return BlogsService.Get(id);
        }
        [Route("api/blogs/create")]
        [HttpPost]
        public HttpResponseMessage Create(BlogModel blog)
        {
            BlogsService.Create(blog);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [Route("api/blogs/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BlogModel blog)
        {
            BlogsService.Edit(blog);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [Route("api/blogs/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            BlogsService.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
