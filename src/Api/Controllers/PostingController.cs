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

    [HttpPost]
    public async Task<ActionResult> AddPosting(AddPostingRequest request)
    {
        await _postingService.AddPosting(request);

        return Ok();
    }
}
