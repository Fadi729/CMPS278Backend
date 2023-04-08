using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMPS278Backend.Data;
using CMPS278Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMPS278Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksDataController : ControllerBase
    {
        //private static List<BooksData> books = new List<BooksData>
        //    {
        //        new BooksData
        //        {
        //            Id = 1,
        //            Title = "Test Title",
        //            Description = "This is a test description",
        //            Authors = "Test Author",
        //            Image = "google.com",
        //            PreviewLink = "youtube.com",
        //            Publisher = "Test publisher",
        //            PublishedDate = "1-1-2001",
        //            InfoLink = "twitter.com",
        //            Categories = "Test category",
        //            RatingsCount = 5
        //        }
        //    };


        private readonly CMPS278DbContext _context;

        public BooksDataController(CMPS278DbContext context)
        {
            _context = context;
            
        }

        // to get all books
        [HttpGet]
        public async Task<ActionResult<List<BooksData>>> Get()
        {
            return Ok(await _context.BooksDatas.ToListAsync());
        }


        // to get a single book
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksData>> Get(string id)
        {
            var book = await _context.BooksDatas.FindAsync(id);

            if (book == null)
            {
                return BadRequest("Book not found!");
            }
            return Ok(book);
        }


        // to post a book
        [HttpPost]
        public async Task<ActionResult<List<BooksData>>> AddBook(BooksData book)
        {
            _context.BooksDatas.Add(book);
            await _context.SaveChangesAsync();
            return Ok(await _context.BooksDatas.ToListAsync());
        }

        // to delete a book
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BooksData>>> Delete(string id)
        {
            var book = await _context.BooksDatas.FindAsync(id);

            if (book == null)
            {
                return BadRequest("Book not found!");
            }
            _context.BooksDatas.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(await _context.BooksDatas.ToListAsync());
        }

    }
}

