using Microsoft.AspNetCore.Mvc;
using CMPS278Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CMPS278Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly CMPS278DataContext _context;

    public MoviesController(CMPS278DataContext context)
    {
        _context = context;
    }

    // GET: Movies
    [HttpGet]
    public async Task<ActionResult<List<Movies>>> Get()
    {

        return Ok(await _context.Movies.ToListAsync());

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<Movies>>> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return BadRequest("Movie not found");
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<List<Movies>>> AddMovie(Movies new_movie)
    {
        _context.Movies.Add(new_movie);
        await _context.SaveChangesAsync();
        return Ok(await _context.Movies.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<Movies>>> UpdateMovie(Movies request)
    {

        var dbMovie = await _context.Movies.FindAsync(request.ID);
        if (dbMovie == null)
            return BadRequest("Movie not found");
        dbMovie.title = request.title;
        dbMovie.image = request.image;
        dbMovie.rating = request.rating;
        dbMovie.genres = request.genres;
        dbMovie.trailer = request.trailer;
        dbMovie.cast = request.cast;
        dbMovie.credits = request.credits;
        dbMovie.description = request.description;
        dbMovie.price = request.price;
        dbMovie.reviews = request.reviews;
        await _context.SaveChangesAsync();
        return (await _context.Movies.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Movies>>> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return BadRequest("Movie not found");
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return Ok(await _context.Movies.ToListAsync());
    }

    // GET: Movies/Details/5
}