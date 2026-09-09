namespace CatBlog.API.Models;

public class Article
{
    public string? Title { get; set; }
    public DateTime? Created { get; set; }
    public string? Author { get; set; }
    public string? Content { get; set; }
}
