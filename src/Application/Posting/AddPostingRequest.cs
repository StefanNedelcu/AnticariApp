namespace AnticariApp.Application.Posting;

public class AddPostingRequest
{
    public long UserId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Category { get; set; }

    public string Thumbnail { get; set; }

    public string Publisher { get; set; }

    public long Price { get; set; }

    public string Description { get; set; }
}