using System.ComponentModel.DataAnnotations;

namespace CMPS278Backend.Models;

public class WishList
{
    [Key] 
    public string                    UserId { get; set; }
    public ICollection<WishListItem> Items  { get; set; }
}

public class WishListItem
{
    public string ItemType { get; set; }
    public string ItemId   { get; set; }
}