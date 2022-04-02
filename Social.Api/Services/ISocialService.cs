using Social.Common.Entities;
using Social.Common.Models;

namespace Social.Api.Services
{
    public interface ISocialService
    {
        IEnumerable<Post> GetPosts();
        Post AddNewPost(AddPostModel model);
    }
}
