using Social.Common.Entities;

namespace Social.Api.Services
{
    public interface ISocialService
    {
        IEnumerable<Post> GetPublicPosts();
        string AddNewPost();// // dodsć model AddPostModel;
            // wyjaśnić Dependncy Injection
    }
}
