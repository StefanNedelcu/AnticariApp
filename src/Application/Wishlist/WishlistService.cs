using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using AnticariApp.Data.Entities;
using AnticariApp.Utils.Enums;
using AnticariApp.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AnticariApp.Application.Wishlist;

public interface IWishlistService
{
    public Task<List<WishlistItem>> GetWishlist(long userId);

    public Task<WishlistItem> AddWishlistItem(long userId, AddWishlistItemRequest request);

    public Task MarkItemRead(long itemId);

    public Task DeleteItem(long itemId);
}

public class WishlistService : DataService, IWishlistService
{
    private readonly MySqlContext _context;

    public WishlistService(MySqlContext context)
    {
        _context = context;
    }

    public async Task<List<WishlistItem>> GetWishlist(long userId)
    {
        return await _context.TBUserWishlistItems
            .Where(i => i.IdUser == userId)
            .Select(i => new WishlistItem
            {
                ItemId = i.IdWishlistItem,
                BookTitle = i.Book.BookTitle,
                AuthorName = i.Book.Author.AuthorName,
                Status = i.ItemStatus.AsEnum<WishlistItemStatus>(),
            })
            .ToListAsync();
    }

    public async Task<WishlistItem> AddWishlistItem(long userId, AddWishlistItemRequest request)
    {
        var book = _context.TBBooks
            .FirstOrDefault(b => b.BookTitle.ToLower() == request.BookTitle.ToLower());

        if (book == null)
        {
            var author = new TBAuthor
            {
                AuthorName = request.AuthorName,
            };

            book = new TBBook
            {
                BookTitle = request.BookTitle,
                Author = author,
            };

            _context.TBAuthors.Add(author);
            _context.TBBooks.Add(book);
        }

        var newItem = new TBUserWishlistItem
        {
            IdUser = userId,
            Book = book,
            ItemStatus = WishlistItemStatus.Wished.AsInt(),
        };

        _context.TBUserWishlistItems.Add(newItem);

        await _context.SaveChangesAsync();

        return new WishlistItem
        {
            ItemId = newItem.IdWishlistItem,
            AuthorName = request.AuthorName,
            BookTitle = request.BookTitle,
            Status = newItem.ItemStatus.AsEnum<WishlistItemStatus>(),
        };
    }

    public async Task MarkItemRead(long itemId)
    {
        var wishlistItem = _context.TBUserWishlistItems
            .First(i => i.IdWishlistItem == itemId);
        var userStatistics = _context.TBUserStatistics
            .First(s => s.IdUser == wishlistItem.IdUser);

        wishlistItem.ItemStatus = WishlistItemStatus.Read.AsInt();
        userStatistics.ReadBooks += 1;
        userStatistics.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteItem(long itemId)
    {
        var wishlistItem = _context.TBUserWishlistItems
            .First(i => i.IdWishlistItem == itemId);

        _context.TBUserWishlistItems.Remove(wishlistItem);

        await _context.SaveChangesAsync();
    }    
}
