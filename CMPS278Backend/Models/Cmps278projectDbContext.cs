using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CMPS278Backend.Models;

public partial class Cmps278projectDbContext : DbContext
{
    public Cmps278projectDbContext()
    {
    }

    public Cmps278projectDbContext(DbContextOptions<Cmps278projectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BooksData> BooksDatas { get; set; }

    public virtual DbSet<BooksReview> BooksReviews { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:cmps278project.database.windows.net,1433;Initial Catalog=CMPS278ProjectDb;Persist Security Info=False;User ID=CMPS278Project;Password=CMPS278GoogleMock;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BooksData>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BooksDat__3214EC07DBA92E56");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Authors)
                .HasMaxLength(270)
                .IsUnicode(false)
                .HasColumnName("authors");
            entity.Property(e => e.Categories)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categories");
            entity.Property(e => e.Description)
                .HasMaxLength(3970)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(111)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.InfoLink)
                .HasMaxLength(261)
                .IsUnicode(false)
                .HasColumnName("infoLink");
            entity.Property(e => e.PreviewLink)
                .HasMaxLength(411)
                .IsUnicode(false)
                .HasColumnName("previewLink");
            entity.Property(e => e.PublishedDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("publishedDate");
            entity.Property(e => e.Publisher)
                .HasMaxLength(49)
                .IsUnicode(false)
                .HasColumnName("publisher");
            entity.Property(e => e.RatingsCount).HasColumnName("ratingsCount");
            entity.Property(e => e.Title)
                .HasMaxLength(192)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BooksReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BooksRev__3214EC07C302111E");

            entity.Property(e => e.Book_Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Book_ID");
            entity.Property(e => e.Price).HasColumnType("numeric(6, 2)");
            entity.Property(e => e.ProfileName)
                .HasMaxLength(49)
                .IsUnicode(false)
                .HasColumnName("profileName");
            entity.Property(e => e.Reviewhelpfulness)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("reviewhelpfulness");
            entity.Property(e => e.Reviewscore)
                .HasColumnType("numeric(3, 1)")
                .HasColumnName("reviewscore");
            entity.Property(e => e.Reviewsummary)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("reviewsummary");
            entity.Property(e => e.Reviewtext)
                .IsUnicode(false)
                .HasColumnName("reviewtext");
            entity.Property(e => e.Reviewtime).HasColumnName("reviewtime");
            entity.Property(e => e.Title)
                .HasMaxLength(192)
                .IsUnicode(false);
            entity.Property(e => e.User_Id)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("User_id");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_moviesdata");

            entity.ToTable("movies", "data");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Cast).HasColumnName("cast");
            entity.Property(e => e.Credits)
                .HasMaxLength(2850)
                .HasColumnName("credits");
            entity.Property(e => e.Description)
                .HasMaxLength(2200)
                .HasColumnName("description");
            entity.Property(e => e.Genres)
                .HasMaxLength(100)
                .HasColumnName("genres");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .HasColumnName("image");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Reviews).HasColumnName("reviews");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Trailer)
                .HasMaxLength(100)
                .HasColumnName("trailer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
