using Microsoft.EntityFrameworkCore;
using Social.Api.Database;

namespace Social.Api.Repository;

public class SocialRepository : ISocialRepository
{
    private readonly SanSocialContext _ctx;
    
    public SocialRepository(SanSocialContext ctx)
    {
        _ctx = ctx;
    }
    
    public IEnumerable<SocialPost> GetPosts()
    {
        return _ctx.SocialPosts.Include(p => p.User);
    }

    public int AddPost(SocialPost post)
    {
        try
        {
            _ctx.Add(post);
            _ctx.SaveChanges();
            return post.PostId;
        }
        catch (Exception)
        {
            return 0;
        }
       
    }
}