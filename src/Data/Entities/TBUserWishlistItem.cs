#nullable disable

namespace AnticariApp.Data.Entities;

public partial class TBUserWishlistItem
{
    public long IdWishlistItem { get; set; }
    public long IdUser { get; set; }
    public long IdBook { get; set; }

    public virtual TBBook Book { get; set; }
    public virtual TBUser User { get; set; }
}
