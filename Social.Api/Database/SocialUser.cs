using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Social.Api.Database
{
    [Table("SocialUser")]
    [Index("UserName", Name = "IX_SocialUser", IsUnique = true)]
    public partial class SocialUser
    {
        public SocialUser()
        {
            SocialComments = new HashSet<SocialComment>();
            SocialLikes = new HashSet<SocialLike>();
            SocialPosts = new HashSet<SocialPost>();
        }

        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string PasswordSalt { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<SocialComment> SocialComments { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<SocialLike> SocialLikes { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<SocialPost> SocialPosts { get; set; }
    }
}
