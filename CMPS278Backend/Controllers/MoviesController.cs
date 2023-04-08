using Microsoft.AspNetCore.Mvc;
using CMPS278Backend.Data;


namespace CMPS278Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly CMPS278DbContext _context;

    public MoviesController(CMPS278DbContext context)
    {
        _context = context;
    }

    private static List<Movies> Movies = new List<Movies>
    {
        new Movies
        {
            ID          = 1,
            title       = "test",
            image       = "test",
            rating      = 1,
            genres      = "test",
            trailer     = "test",
            cast        = "test",
            credits     = "test",
            description = "test",
            price       = 1,
            reviews     = "test"
        },
        new Movies
        {
            ID          = 2,
            title       = "test",
            image       = "test",
            rating      = 1,
            genres      = "test",
            trailer     = "test",
            cast        = "test",
            credits     = "test",
            description = "test",
            price       = 1,
            reviews     = "test"
        }
    };

    // GET: Movies
    [HttpGet]
    public async Task<ActionResult<List<Movies>>> Get()
    {
        return Ok(Movies);
    }

    // GET: Movies/Details/5
}