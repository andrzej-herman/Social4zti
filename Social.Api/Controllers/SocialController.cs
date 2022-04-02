using Microsoft.AspNetCore.Mvc;
using Social.Api.Services;
using Social.Common.Entities;
using Social.Common.Models;

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
        public IEnumerable<Post> GetPosts()
        {
            return _service.GetPosts();
        }


        [HttpPost]
        [Route("posts")]
        public Post AddPost(AddPostModel model)
        {
            return _service.AddNewPost(model);
        }


    }
}