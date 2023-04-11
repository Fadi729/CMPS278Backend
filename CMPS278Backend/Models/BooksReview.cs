namespace CMPS278Backend.Models;

public partial class BooksReview
{
    public int Id { get; set; }

    public string Book_Id { get; set; } = null!;

    public string? Title { get; set; }

    public decimal? Price { get; set; }

    public string? User_Id { get; set; }

    public string? ProfileName { get; set; }

    public string Reviewhelpfulness { get; set; } = null!;

    public decimal Reviewscore { get; set; }

    public int Reviewtime { get; set; }

    public string Reviewsummary { get; set; } = null!;

    public string Reviewtext { get; set; } = null!;
}
