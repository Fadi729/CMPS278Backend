using System.Text.Json;
using CMPS278Backend.Models.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMPS278Backend.Models;

public partial class CMPS278DataContext : DbContext
{
    public CMPS278DataContext(DbContextOptions<CMPS278DataContext> options) : base(options)
    {
    }

    public virtual DbSet<BooksData> BooksDatas { get; set; }

    public virtual DbSet<BooksReview> BooksReviews { get; set; }

    public virtual DbSet<ApplicationData> ApplicationData { get; set; }

    public virtual DbSet<ApplicationReview> ApplicationReviews { get; set; }

    public virtual DbSet<GameData> GameData { get; set; }

    public virtual DbSet<GameReview> GameReviews { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder
           .UseSqlServer("name=ConnectionStrings:CMPS278ProjectDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<ApplicationData>(BaseModelBuilder);
        
        modelBuilder.Entity<GameData>(BaseModelBuilder);

        OnModelCreatingPartial(modelBuilder);
    }

    static void BaseModelBuilder<T>(EntityTypeBuilder<T> entity) where T : BaseDataModel
    {
          entity.HasKey(e => e.AppId);

          entity.Property(e => e.Histogram)
                .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), v => JsonSerializer.Deserialize<IDictionary<string, int>>(v, (JsonSerializerOptions)null));

          entity.Property(e => e.Screenshots)
                .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), v => JsonSerializer.Deserialize<IList<string>>(v, (JsonSerializerOptions)null));

          entity.Property(e => e.Comments)
                .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null), v => JsonSerializer.Deserialize<IList<string>>(v, (JsonSerializerOptions)null));
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}