namespace AnticariApp.Application.Posting;

public class Posting
{
    public long PostingId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Category { get; set; }

    public string Thumbnail { get; set; }

    public string Publisher { get; set; }

    public decimal? Price { get; set; }

    public string Description { get; set; }

    public User.User Owner { get; set; }

    public DateTime CreatedAt { get; set; }
}