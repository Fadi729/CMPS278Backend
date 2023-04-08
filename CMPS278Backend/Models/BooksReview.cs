using System;
namespace CMPS278Backend.Models
{
	public class BooksReview
	{
        public int Id { get; set; }
        public string Book_ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Price { get; set; }
        public string User_id { get; set; } = string.Empty;
        public string profileName { get; set; } = string.Empty;
        public int reviewhelpfulness { get; set; }
        public int reviewscore { get; set; }
        public string reviewsummary { get; set; } = string.Empty;
        public string reviewtext { get; set; } = string.Empty;

    }
}

