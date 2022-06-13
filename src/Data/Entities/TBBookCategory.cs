#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBBookCategory
{
    public long IdBookCategory { get; set; }
    public long IdCategory { get; set; }
    public long IdBook { get; set; }

    public virtual TBBook IdBookNavigation { get; set; }
    public virtual TBCategory IdCategoryNavigation { get; set; }
}
