using Microsoft.AspNetCore.Mvc;
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
        private BlogController _controllerUnderTest;
        private Mock<IBlogsService> _moqService;

        [Fact]
        public async void Get_returnsAllPosts()
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

            _moqService = new Mock<IBlogsService>();
            _moqService.Setup(x => x.GetAsync())
                .ReturnsAsync(posts);

            _controllerUnderTest = new BlogController(_moqService.Object);

            //Act
            var value = await _controllerUnderTest.Get();

            //Assert
            Assert.Same(value, posts);
        }

        [Fact]
        public async void get_ReturnsPostForGivenId()
        {
            //Arrange
            string postId = "12345678901234567890";
            var post = new Post()
            {
                Id = postId,
                Title = "some test title",
                Author = "test author",
                Body = "random test body",
                Category = "test"
            };

            _moqService = new Mock<IBlogsService>();
            _moqService.Setup(x => x.GetAsync(postId))
                .ReturnsAsync(post);

            _controllerUnderTest = new BlogController(_moqService.Object);

            //Act
            var result = await _controllerUnderTest.Get(postId);

            //Assert
            Assert.Same(post, result.Value);
        }

        [Fact]
        public async void get_ReturnsNotFoundErrorForUnkownId()
        {
            //Arrange
            string postId = "12345678901234567890";
            var post = new Post()
            {
                Id = postId,
                Title = "some test title",
                Author = "test author",
                Body = "random test body",
                Category = "test"
            };

            _moqService = new Mock<IBlogsService>();
            _moqService.Setup(x => x.GetAsync(postId))
                .ReturnsAsync(post);

            _controllerUnderTest = new BlogController(_moqService.Object);

            //Act
            var result = await _controllerUnderTest.Get("0987654321234567890");

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }

        [Fact]
        public async void post_returnsCreatedResponse()
        {
            //Arrange
            string postId = "12345678901234567890";
            var post = new Post()
            {
                Id = postId,
                Title = "some test title",
                Author = "test author",
                Body = "random test body",
                Category = "test"
            };

            _moqService = new Mock<IBlogsService>();
            _moqService.Setup(x => x.CreateAsync(post))
                .Verifiable();

            _controllerUnderTest = new BlogController(_moqService.Object);

            //Act
            var result = await _controllerUnderTest.Post(post);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CreatedAtActionResult>(result);
            //Assert.Equal(10, result.RouteValues["id"]);

        }
    }
}
