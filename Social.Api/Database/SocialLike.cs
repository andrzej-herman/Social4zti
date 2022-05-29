using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Social.Api.Database
{
    [Table("SocialLike")]
    public partial class SocialLike
    {
        [Key]
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("PostId")]
        [InverseProperty("SocialLikes")]
        public virtual SocialPost Post { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("SocialLikes")]
        public virtual SocialUser User { get; set; }
    }
}
