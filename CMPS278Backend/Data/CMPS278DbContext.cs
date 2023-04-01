using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMPS278Backend.Data;

public class CMPS278DbContext : IdentityDbContext<IdentityUser>
{
    public CMPS278DbContext(DbContextOptions<CMPS278DbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
}