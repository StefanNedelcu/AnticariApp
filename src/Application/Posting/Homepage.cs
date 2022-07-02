namespace AnticariApp.Application.Posting;

public class Homepage
{
    public List<Posting> Recommendations { get; set; } = new();

    public List<Posting> Latest { get; set; } = new();
}