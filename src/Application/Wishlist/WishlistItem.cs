using AnticariApp.Utils.Enums;

namespace AnticariApp.Application.Wishlist;

public class WishlistItem
{
    public long ItemId { get; set; }

    public string BookTitle { get; set; }

    public string AuthorName { get; set; }

    public WishlistItemStatus Status { get; set; }
}
