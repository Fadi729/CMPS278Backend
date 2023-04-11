using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMPS278Backend.Data;

public class CMPS278IdentityContext : IdentityDbContext<IdentityUser>
{
    public CMPS278IdentityContext(DbContextOptions<CMPS278IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    
}