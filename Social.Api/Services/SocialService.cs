using Social.Common.Entities;
using Social.Common.Models;
using Blazored.LocalStorage;
using Newtonsoft.Json;

namespace Social.Api.Services
{
    public class SocialService : ISocialService
    {
        private List<Post> _posts = new List<Post>();
        private List<Like> _likes = new List<Like>();
        private List<Comment> _comments = new List<Comment>();



        public Post AddNewPost(AddPostModel model)
        {
            var post = new Post
            {
                PostId = Guid.NewGuid().ToString().Replace("-", ""),
                Title = model.Title,
                Text = model.Text,
                ImageUrl = model.ImageUrl,
                IsPublic = model.IsPublic,
                DateAdd = DateTime.Now,
                AuthorId = model.AuthorId,
                AuthorName = model.AuthorName,
            };

            _posts.Add(post);
            return post;
        }

        public IEnumerable<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            posts = _posts.Where(p => p.IsPublic).OrderByDescending(p => p.DateAdd).ToList();
            foreach (var post in posts)
            {
                post.Likes = _likes.Where(l => l.PostId == post.PostId).ToList(); 
                post.Comments = _comments.Where(l => l.PostId == post.PostId).ToList();
            }

            return posts;   
        }
    }
}
