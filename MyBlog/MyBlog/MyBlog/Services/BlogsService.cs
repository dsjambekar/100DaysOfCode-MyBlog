using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class BlogsService
    {
        private readonly IMongoCollection<Post> _postsCollection;

        public BlogsService(
            IOptions<BlogDatabaseSettings> blogStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                blogStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                blogStoreDatabaseSettings.Value.DatabaseName);

            _postsCollection = mongoDatabase.GetCollection<Post>(
                blogStoreDatabaseSettings.Value.PostsCollectionName);
        }

        public async Task<List<Post>> GetAsync() =>
            await _postsCollection.Find(_ => true).ToListAsync();

        public async Task<Post?> GetAsync(string id) =>
            await _postsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Post newPost) =>
            await _postsCollection.InsertOneAsync(newPost);

        public async Task UpdateAsync(string id, Post updatedPost) =>
            await _postsCollection.ReplaceOneAsync(x => x.Id == id, updatedPost);

        public async Task RemoveAsync(string id) =>
            await _postsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
