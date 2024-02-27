using Test_Web_API.DTOs;

namespace Test_Web_API.Services
{
    public interface IPostsService
    {
        // IEnumerable<> only allows iteration, but not other specific methods such as List<> iteration
        public Task<IEnumerable<PostDto>> GetPostsAsync();
    }
}
