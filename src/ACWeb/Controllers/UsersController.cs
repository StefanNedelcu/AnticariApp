using ACEntities.Context;
using ACEntities.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace ACWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ACContext _context;

        public UsersController(ACContext context)
        {
            _context = context;
        }

        [HttpGet("chestie")]
        public IEnumerable<TBUser> GetUsers()
        {
            return _context.TBUsers;
        }

        [HttpGet("{id}")] // search syntax
        public TBUser GetUser(long id)
        {
            return null;
        }

        [HttpGet("/api/books/{id}")]
        public TBBook GetBook(long id)
        {
            return null;
        }
    }
}
