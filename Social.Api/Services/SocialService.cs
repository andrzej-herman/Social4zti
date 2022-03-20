using Social.Common.Entities;

namespace Social.Api.Services
{
    public class SocialService : ISocialService
    {
        private List<Post> _posts = new List<Post>();
        private List<Like> _likes = new List<Like>();
        private List<Comment> _comments = new List<Comment>();

        public string AddNewPost()
        {
            _posts.Add(post);

        }

        public IEnumerable<Post> GetPublicPosts()
        {
            var posts = _posts.Where(p => p.IsPublic);
            foreach (var post in posts)
            {
                post.Likes = _likes.Where(l => l.PostId == post.PostId).ToList(); 
                post.Comments = _comments.Where(l => l.PostId == post.PostId).ToList();
            }

            return posts;   
        }
    }
}
