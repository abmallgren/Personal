using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Data;
using Microsoft.Extensions.Configuration;

namespace Portal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private IConfiguration _configuration;
        public BlogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            BlogContext context = new BlogContext(_configuration.GetConnectionString("Core"));
            var blogPosts = from bp in context.BlogPosts
                            orderby bp.PostedOn descending
                            select bp;
            return Json(blogPosts);
        }
    }
}
