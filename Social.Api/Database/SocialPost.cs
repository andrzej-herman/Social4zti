using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Social.Api.Database
{
    [Table("SocialPost")]
    public partial class SocialPost
    {
        public SocialPost()
        {
            SocialComments = new HashSet<SocialComment>();
            SocialLikes = new HashSet<SocialLike>();
        }

        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string PostText { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("SocialPosts")]
        public virtual SocialUser User { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<SocialComment> SocialComments { get; set; }
        [InverseProperty("Post")]
        public virtual ICollection<SocialLike> SocialLikes { get; set; }
    }
}
