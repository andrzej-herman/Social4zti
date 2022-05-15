using System.ComponentModel.DataAnnotations;

namespace Social.Common.Dtos;

public class AddPostDto
{
    [Required] public int UserId { get; set; }

    public string Title { get; set; }

    [Required(ErrorMessage = "Proszę podać treść posta")]
    public string PostText { get; set; }

    public string ImageUrl { get; set; }
    
}