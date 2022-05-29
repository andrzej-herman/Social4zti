
using System.Xml;
using Social.Api.Database;
using Social.Api.Repository;
using Social.Common.Dtos;

namespace Social.Api.Services
{
    public class SocialService : ISocialService
    {
        private readonly ISocialRepository _repo;

        public SocialService(ISocialRepository repo)
        {
            _repo = repo;
        }
        
        
        public IEnumerable<PostDto> GetPosts()
        {
            return _repo.GetPosts().Select(p => new PostDto()
            {
                PostId = p.PostId,
                UserId = p.UserId,
                DateCreated = p.DateCreated,
                PostText = p.PostText,
                Title = p.Title,
                ImageUrl = p.ImageUrl,
                Author =  $"{p.User.FirstName} {p.User.LastName}",
                Initials = $"{p.User.FirstName[..1].ToUpper()}{p.User.LastName[..1].ToUpper()}"
            });
        }

        public ResultDto AddPost(AddPostDto dto)
        {
            var post = new SocialPost()
            {
                UserId = dto.UserId,
                DateCreated = DateTime.Now,
                Title = dto.Title,
                PostText = dto.PostText,
                ImageUrl = dto.ImageUrl
            };

            var value = _repo.AddPost(post);
            return value != 0 ? 
                new ResultDto() {Result = true, Description = "Post został dodany"} 
                : new ResultDto() {Result = false, 
                    Description = "Wystąpił problem z dodaniem posta, spróbuj później"};

        }
    }
}

