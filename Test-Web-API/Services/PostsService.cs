using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Test_Web_API.DTOs;

namespace Test_Web_API.Services
{
    public class PostsService : IPostsService
    {
        private HttpClient _httpClient;

        public PostsService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PostDto>> GetPostsAsync()
        {
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();
            
            // The properties in PostsDto are in upper case and from the JsonPlaceHolder page they come in lower case which causes an error, to avoid this we use this rule to ignore the case sensitive
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);


            return post;
        }

    }
}
