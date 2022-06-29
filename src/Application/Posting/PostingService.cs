using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using AnticariApp.Data.Entities;
using AnticariApp.Utils.Enums;
using Microsoft.EntityFrameworkCore;

namespace AnticariApp.Application.Posting;

public interface IPostingService
{
    public Task AddPosting(AddPostingRequest request);
}

public class PostingService : DataService, IPostingService
{
    private readonly MySqlContext _context;

    public PostingService(MySqlContext context)
    {
        _context = context;
    }

    public async Task AddPosting(AddPostingRequest request)
    {
        var user = _context.TBUsers
            .First(u => u.IdUser == request.UserId);

        var author = new TBAuthor
        {
            AuthorName = request.Author,
        };

        var category = new TBCategory
        {
            CategoryName = request.Category,
        };

        var book = new TBBook
        {
            BookTitle = request.Title,
            BookDescription = request.Description,
            Author = author,
        };

        var bookCategory = new TBBookCategory
        {
            Book = book,
            Category = category,
        };

        var posting = new TBPosting
        {
            Book = book,
            PostingDescription = request.Description,
            Owner = user,
            Price = request.Price,
            PostingStatus = (int)PostingStatus.Available,
            CreatedAt = DateTime.Now,
        };

        var image = new TBPostingImage
        {
            Posting = posting,
            ImgSrc = request.Thumbnail,
        };

        _context.TBAuthors.Add(author);
        _context.TBCategories.Add(category);
        _context.TBBooks.Add(book);
        _context.TBBookCategories.Add(bookCategory);
        _context.TBPostings.Add(posting);
        _context.TBPostingImages.Add(image);

        await _context.SaveChangesAsync();
    }
}
