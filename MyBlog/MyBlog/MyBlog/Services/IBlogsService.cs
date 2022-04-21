using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public interface IBlogsService
    {
        Task<List<Post>> GetAsync(); 

         Task<Post?> GetAsync(string id);

        Task CreateAsync(Post newPost);

        Task UpdateAsync(string id, Post updatedPost);

        Task RemoveAsync(string id);
    }
}
