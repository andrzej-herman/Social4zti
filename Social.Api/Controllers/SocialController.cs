using Microsoft.AspNetCore.Mvc;
using Social.Api.Services;
using Social.Common.Dtos;

namespace Social.Api.Controllers
{
    [ApiController]
    public class SocialController : ControllerBase
    {
        private readonly ISocialService _service;
        
        public SocialController(ISocialService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("posts")]
        public IEnumerable<PostDto> GetPosts()
        {
            return _service.GetPosts();
        }
        
        [HttpPost]
        [Route("posts")]
        public ResultDto AddPost(AddPostDto dto)
        {
            return _service.AddPost(dto);
        }
    }
}