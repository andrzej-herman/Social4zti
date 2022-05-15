namespace Social.Common.Dtos;

public class PostDto
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Author { get; set; }
    public DateTime DateCreated { get; set; }
    public string Title { get; set; }
    public string PostText { get; set; }
    public string ImageUrl { get; set; }
}