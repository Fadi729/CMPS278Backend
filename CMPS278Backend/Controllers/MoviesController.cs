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
public class MoviesController : ControllerBase
    {
        private readonly CMPS278DbContext _context;

        public MoviesController(CMPS278DbContext context)
        {
            _context = context;
        }
        private static List<Movie> Movies = new List<Movie>
            {
                new Movie
                {
                    ID = 1,
                    title="test",
                    image="test",
                    rating=1,
                    genres="test",
                    trailer="test",
                    cast="test",
                    credits="test",
                    description="test",
                    price=1,
                    reviews="test"
                },
                new Movie
                {
                    ID = 2,
                    title="test",
                    image="test",
                    rating=1,
                    genres="test",
                    trailer="test",
                    cast="test",
                    credits="test",
                    description="test",
                    price=1,
                    reviews="test"
                }

            };
        // GET: Movies
        [HttpGet(Name ="GetMovies")]
        public async Task<ActionResult<List<Movie>>> Get()
        {

            return Ok(Movies);
            
        }

        // GET: Movies/Details/5
        
    }
}
