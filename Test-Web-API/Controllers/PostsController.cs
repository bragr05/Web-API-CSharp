using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Web_API.DTOs;
using Test_Web_API.Services;

namespace Test_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostsService _postService;

        public PostsController(IPostsService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> GetPosts() => await _postService.GetPostsAsync();
    }
}
