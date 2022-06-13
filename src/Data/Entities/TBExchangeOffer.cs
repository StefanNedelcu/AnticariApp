#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBExchangeOffer
{
    public long IdExchangeOffer { get; set; }
    public long IdPosting { get; set; }
    public long? IdAuthor { get; set; }
    public long? IdCategory { get; set; }
    public long? IdBook { get; set; }

    public virtual TBAuthor Author { get; set; }
    public virtual TBBook Book { get; set; }
    public virtual TBCategory Category { get; set; }
    public virtual TBPosting Posting { get; set; }
}
