using AnticariApp.Application.Wishlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnticariApp.API.Controllers;

public class WishlistController : ACController
{
    private readonly IWishlistService _wishlistService;

    public WishlistController(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<WishlistItem>>> GetWishlist(long userId)
    {
        var result = await _wishlistService.GetWishlist(userId);

        return Ok(result);
    }

    [HttpPost("user/{userId}")]
    public async Task<ActionResult<WishlistItem>> AddWishlistItem(
        long userId, 
        [FromBody] AddWishlistItemRequest request)
    {
        var result = await _wishlistService.AddWishlistItem(userId, request);

        return Ok(result);
    }

    [HttpPatch("{itemId}")]
    public async Task<ActionResult> MarkItemRead(long itemId)
    {
        await _wishlistService.MarkItemRead(itemId);

        return Ok();
    }

    [HttpDelete("{itemId}")]
    public async Task<ActionResult> DeleteItem(long itemId)
    {
        await _wishlistService.DeleteItem(itemId);

        return Ok();
    }
}
