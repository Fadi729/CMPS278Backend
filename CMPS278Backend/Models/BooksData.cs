using System;
namespace CMPS278Backend.Models
{
	public class BooksData
	{
            public string Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string description { get; set; } = string.Empty;
            public string authors { get; set; } = string.Empty;
            public string image { get; set; } = string.Empty;
            public string previewLink { get; set; } = string.Empty;
            public string publisher { get; set; } = string.Empty;
            public string publishedDate { get; set; } = string.Empty;
            public string infoLink { get; set; } = string.Empty;
            public string categories { get; set; } = string.Empty;
            public int ratingsCount { get; set; }
      
	}
}

