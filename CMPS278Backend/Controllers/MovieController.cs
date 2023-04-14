using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMPS278Backend;
using CMPS278Backend.Data;
using CMPS278Backend.Models;


namespace CMPS278Backend.Controllers

{
    
[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
    {
        private readonly CMPS278DbContext _context;

        public MovieController(CMPS278DbContext context)
        {
            _context = context;
        }
        
        // GET: Movies
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {

            return Ok(await _context.Movies.ToListAsync());
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Movie>>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if(movie == null)
                return BadRequest("Movie not found");
            return Ok(movie);

        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie new_movie)
        {
            _context.Movies.Add(new_movie);
            await _context.SaveChangesAsync();
            return Ok(await _context.Movies.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(Movie request)
        {

            var dbMovie = await _context.Movies.FindAsync(request.ID);
            if (dbMovie == null)
                return BadRequest("Movie not found");
            dbMovie.title = request.title;
            dbMovie.image = request.image;
            dbMovie.rating = request.rating;
            dbMovie.genres = request.genres;
            dbMovie.trailer = request.trailer;
            dbMovie.cast= request.cast;
            dbMovie.credits=request.credits;
            dbMovie.description=request.description;
            dbMovie.price=request.price;
            dbMovie.reviews=request.reviews;
            await _context.SaveChangesAsync();
            return(await _context.Movies.ToListAsync());    
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(int id)
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
}
