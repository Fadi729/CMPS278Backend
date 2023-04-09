using CMPS278Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CMPS278Backend;

namespace CMPS278Backend.Data;

public class CMPS278IdentityContext : IdentityDbContext<IdentityUser>
{
    public CMPS278IdentityContext(DbContextOptions<CMPS278IdentityContext> options)
        : base(options)
    {
    }

    // public DbSet<BooksData> BooksDatas { get; set;}
    // public DbSet<BooksReview> BooksReviews { get; set; }
    // public DbSet<CMPS278Backend.Movies> Movies { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    
}