namespace CMPS278Backend.Models;

public partial class BooksData
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Authors { get; set; }

    public string? Image { get; set; }

    public string? PreviewLink { get; set; }

    public string? Publisher { get; set; }

    public string? PublishedDate { get; set; }

    public string? InfoLink { get; set; }

    public string? Categories { get; set; }

    public int? RatingsCount { get; set; }
}
