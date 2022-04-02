using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Common.Entities
{
    public class Post
    {
        public string PostId { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateAdd { get; set; }
        public bool IsPublic { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public int NumberOfLikes
        {
            get
            {
                if (Likes != null && Likes.Any())
                    return Likes.Count;
                else
                    return 0;
            }
        }
        public int NumberOfComments
        {
            get
            {
                if (Comments != null && Comments.Any())
                    return Comments.Count;
                else
                    return 0;
            }
        }
    }
}
