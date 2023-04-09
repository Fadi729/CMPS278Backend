using CMPS278Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CMPS278Backend;

namespace CMPS278Backend.Data;

public class CMPS278DbContext : IdentityDbContext<IdentityUser>
{
    public CMPS278DbContext(DbContextOptions<CMPS278DbContext> options)
        : base(options)
    {
    }

    public DbSet<BooksData> BooksDatas { get; set;}
    public DbSet<BooksReview> BooksReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<CMPS278Backend.Movies> Movies { get; set; } = default!;
    
}