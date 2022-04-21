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
        private readonly IBlogsService _blogsService;

        public BlogController(IBlogsService blogsService)
        {
            _blogsService = blogsService ?? throw new ArgumentNullException(nameof(blogsService));
        }

        [HttpGet]
        public async Task<List<Post>> Get() =>
        await _blogsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Post>> Get(string id)
        {
            var book = await _blogsService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }


        [HttpPost]
        public async Task<IActionResult> Post(Post newPost)
        {
            await _blogsService.CreateAsync(newPost);

            return CreatedAtAction(nameof(Get), new { id = newPost.Id }, newPost);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Post updatedPost)
        {
            var post = await _blogsService.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            updatedPost.Id = post.Id;

            await _blogsService.UpdateAsync(id, updatedPost);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var post = await _blogsService.GetAsync(id);

            if (post is null)
            {
                return NotFound();
            }

            await _blogsService.RemoveAsync(id);

            return NoContent();
        }

    }
}
