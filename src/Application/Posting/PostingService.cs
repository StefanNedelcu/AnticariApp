using AnticariApp.Application.Common;
using AnticariApp.Application.User;
using AnticariApp.Data.Context;
using AnticariApp.Data.Entities;
using AnticariApp.Utils.Enums;
using AnticariApp.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AnticariApp.Application.Posting;

public interface IPostingService
{
    public Homepage GetHomepage(long userId);

    public Task AddPosting(AddPostingRequest request);

    public Task MarkPostingClosed(long postingId, AddReviewRequest request);

    public Task<List<Posting>> Search(SearchFilter filter);
}

public class PostingService : DataService, IPostingService
{
    private readonly MySqlContext _context;

    private readonly IUserService _userService;

    public PostingService(MySqlContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public Homepage GetHomepage(long userId)
    {
        var allPostings = _context.TBPostings
            .Where(p => p.PostingStatus == PostingStatus.Available.AsInt())
            .OrderByDescending(p => p.CreatedAt)
            .Include(p => p.Book)
            .Include(p => p.Book.Author)
            .Include(p => p.TBPostingImages)
            .ToList()
            .Select(p => ToPosting(p))            
            .ToList();

        var recommendations = allPostings
            .Where(p => IsRecommendation(p, userId))            
            .Take(4)
            .ToList();

        var latest = allPostings
            .Where(p => !recommendations.Contains(p))
            .Take(4)
            .ToList();

        return new Homepage
        {
            Recommendations = recommendations,
            Latest = latest,
        };
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

    public async Task MarkPostingClosed(long postingId, AddReviewRequest request)
    {
        var posting = await _context.TBPostings
            .FirstOrDefaultAsync(p => p.IdPosting == postingId);

        var ownerStatistics = await _context.TBUserStatistics
            .FirstOrDefaultAsync(s => s.IdUser == posting.IdOwnerUser);

        if (request.Rating is not null)
        {
            var newRating = (ownerStatistics.UserAvgRating * ownerStatistics.ReviewsReceived + request.Rating)
                / (ownerStatistics.ReviewsReceived + 1);

            ownerStatistics.UserAvgRating = newRating ?? 0;
            ownerStatistics.ReviewsReceived++;
        }
        posting.PostingStatus = PostingStatus.Closed.AsInt();
        ownerStatistics.SoldItems++;

        await _context.SaveChangesAsync();
    }

    public async Task<List<Posting>> Search(SearchFilter filter)
    {
        return _context.TBPostings
            .Where(p => p.PostingStatus == PostingStatus.Available.AsInt())
            .OrderByDescending(p => p.CreatedAt)
            .Include(p => p.Book)
            .Include(p => p.Book.Author)
            .Include(p => p.TBPostingImages)            
            .ToList()
            .Select(p => ToPosting(p))
            .Where(p => filter.Query == string.Empty || 
                p.Title.ToLower().Contains(filter.Query.ToLower()) ||
                p.Author.ToLower().Contains(filter.Query.ToLower()) ||
                p.Category.ToLower().Contains(filter.Query.ToLower()))
            .ToList();
    }

    private bool IsRecommendation(Posting posting, long userId)
    {
        var preferredAuthors = _context.TBUserAuthorPreferences
            .Where(p => p.IdUser == userId)
            .Select(p => p.Author.AuthorName)
            .ToList();
        var preferredCategories = _context.TBUserCategoryPreferences
            .Where(p => p.IdUser == userId)
            .Select(p => p.Category.CategoryName)
            .ToList();

        return preferredAuthors.Contains(posting.Author) || preferredCategories.Contains(posting.Category);
    }

    public Posting ToPosting(TBPosting posting)
    {
        var category = _context.TBBookCategories
            .Where(b => b.IdBook == posting.IdBook)
            .Select(b => b.Category.CategoryName)
            .FirstOrDefault();

        var owner = _userService.GetUser(posting.IdOwnerUser);

        return new Posting
        {
            PostingId = posting.IdPosting,
            Description = posting.PostingDescription,
            Price = posting.Price,
            Title = posting.Book.BookTitle,
            Author = posting.Book.Author.AuthorName,
            Category = category,
            Thumbnail = posting.TBPostingImages.FirstOrDefault()?.ImgSrc,
            Owner = owner,
            CreatedAt = posting.CreatedAt,
        };
    }
}
