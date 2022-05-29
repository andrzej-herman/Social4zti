using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Social.Api.Database
{
    [Table("SocialComment")]
    public partial class SocialComment
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(2000)]
        public string CommentText { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("PostId")]
        [InverseProperty("SocialComments")]
        public virtual SocialPost Post { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("SocialComments")]
        public virtual SocialUser User { get; set; }
    }
}
