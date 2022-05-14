using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Common.Models
{
    public class AddPostModel
    {
        public string Title { get; set; }

        [Required(ErrorMessage = "Proszę podać treść posta")]
        public string Text { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}
