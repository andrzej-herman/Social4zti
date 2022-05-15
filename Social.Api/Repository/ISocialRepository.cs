using Social.Api.Database;

namespace Social.Api.Repository;

public interface ISocialRepository
{
    IEnumerable<SocialPost> GetPosts();
    int AddPost(SocialPost post);
}