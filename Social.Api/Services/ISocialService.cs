using Social.Api.Database;
using Social.Common.Dtos;

namespace Social.Api.Services
{
    public interface ISocialService
    {
        IEnumerable<PostDto> GetPosts();
        ResultDto AddPost(AddPostDto dto);
    }
}
