using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]

    public class BlogController : ControllerBase
    {
        private readonly BlogsService _blogsService;

        public BlogController(BlogsService blogsService)
        {
            _blogsService = blogsService ?? throw new ArgumentNullException(nameof(blogsService));
        }

        [HttpGet]
        public async Task<List<Post>> Get() =>
        await _blogsService.GetAsync();
    }
}
