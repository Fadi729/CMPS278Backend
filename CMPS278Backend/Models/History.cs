using System;
using System.ComponentModel.DataAnnotations;

namespace CMPS278Backend.Models
{
	public class History
	{
            [Key]
            public string UserId { get; set; }
            public IList<HistoryItem> Items { get; set; }
    }

    public class HistoryItem
    {
        public string ItemType { get; set; }
        public string ItemId { get; set; }
    }

}

