using Moq;
using MyBlog.Controllers;
using MyBlog.Models;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyBlogTest
{
    public class BlogControllerTest
    {
        private BlogController _controllerUderTest;

        [Fact]
        public void Get_returnsAllPosts()
        {
            //Arrange
            var post = new Post()
            {
                Id = "12345678901234567890",
                Title = "some test title",
                Author = "test author",
                Body = "random test body",
                Category = "test"
            };

            var posts = new List<Post>() { post };

            Mock<IBlogsService> moqService = new Mock<IBlogsService>();
            moqService.Setup(x => x.GetAsync())
                .ReturnsAsync(posts);

            _controllerUderTest = new BlogController(moqService.Object);

            //Act
            var value = _controllerUderTest.Get();

            //Assert
            Assert.Same(value, posts);


        }
    }
}
