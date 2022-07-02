using AnticariApp.Application.Posting;
using AnticariApp.Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnticariApp.API.Controllers;

public class PostingController : ACController
{
    private readonly IPostingService _postingService;

    public PostingController(IPostingService postingService)
    {
        _postingService = postingService;
    }

    [HttpGet("user/{userId}")]
    public  ActionResult<Homepage> GetHomepage(long userId)
    {
        var result = _postingService.GetHomepage(userId);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddPosting(AddPostingRequest request)
    {
        await _postingService.AddPosting(request);

        return Ok();
    }

    [HttpPatch("{postingId}")]
    public async Task<ActionResult> MarkPostingClosed(
        long postingId,
        [FromBody] AddReviewRequest request)
    {
        await _postingService.MarkPostingClosed(postingId, request);

        return Ok();
    }

    [HttpGet("search")]
    public async Task<ActionResult<List<Posting>>> Search([FromQuery]SearchFilter filter)
    {
        var result = await _postingService.Search(filter);

        return Ok(result);
    }
}
