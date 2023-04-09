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
    public class BooksReviewController : ControllerBase
    {
        //private static List<BooksReview> reviews = new List<BooksReview>
        //    {
        //        new BooksReview
        //        {
        //            Id = 1,
        //            Title = "Test book title",
        //            Price = 55,
        //            UserID = "testtest",
        //            ProfileName = "Profile test name",
        //            PreviewLink = "jdgjdgj",
        //            ReviewHelpfulness = 5,
        //            ReviewTime = 999999,
        //            ReviewSummary = "test summary",
        //            ReviewText = "Test text"
        //        }
        //    };


        private readonly CMPS278DataContext _context;

        public BooksReviewController(CMPS278DataContext context)
        {
            _context = context;

        }

        // to get all book reviews
        [HttpGet]
        public async Task<ActionResult<List<BooksReview>>> Get()
        {
            return Ok(await _context.BooksReviews.ToListAsync());
        }


        // to get a single review
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksReview>> Get(int id)
        {
            var review = await _context.BooksReviews.FindAsync(id);

            if (review == null)
            {
                return BadRequest("Review not found!");
            }
            return Ok(review);
        }


        // to post a review
        [HttpPost]
        public async Task<ActionResult<List<BooksReview>>> AddReview(BooksReview review)
        {
            _context.BooksReviews.Add(review);
            await _context.SaveChangesAsync();
            return Ok(await _context.BooksReviews.ToListAsync());
        }

        // to delete a review
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BooksReview>>> Delete(int id)
        {

            var review = await _context.BooksReviews.FindAsync(id);

            if (review == null)
            {
                return BadRequest("Book not found!");
            }
            _context.BooksReviews.Remove(review);
            await _context.SaveChangesAsync();
            return Ok(await _context.BooksReviews.ToListAsync());

        }

    }
}

