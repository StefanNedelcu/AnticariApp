#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBPostingImage
{
    public long IdPostingImage { get; set; }
    public long IdPosting { get; set; }
    public string ImgSrc { get; set; }

    public virtual TBPosting Posting { get; set; }
}
