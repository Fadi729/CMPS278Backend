using CMPS278Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMPS278Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WishListController : ControllerBase
{
    readonly CMPS278DataContext _context;

    public WishListController(CMPS278DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<WishList>> GetWishList()
    {
        string    userId   = HttpContext.User.Claims.First(c => c.Type == "userId").Value;
        WishList? wishList = await _context.WishList.FindAsync(userId);

        if (wishList == null)
        {
            return NotFound();
        }

        return Ok(wishList);
    }

    // POST: api/WishList
    [HttpPost]
    public async Task<ActionResult> AddItemToWishList(WishListItem item)
    {
        string    userId   = HttpContext.User.Claims.First(c => c.Type == "userId").Value;
        WishList? wishList = await _context.WishList.FindAsync(userId);

        if (wishList == null)
        {
            wishList = new WishList
            {
                UserId = userId,
                Items  = new List<WishListItem>()
            };
            _context.WishList.Add(wishList);
        }

        wishList.Items.Add(item);
        await _context.SaveChangesAsync();

        return Ok();
    }

    // DELETE: api/WishList
    [HttpDelete("{itemId}")]
    public async Task<ActionResult> RemoveItemFromWishList(string itemId)
    {
        string    userId   = HttpContext.User.Claims.First(c => c.Type == "userId").Value;
        WishList? wishList = await _context.WishList.FindAsync(userId);

        if (wishList == null)
        {
            return NotFound();
        }

        WishListItem item = wishList.Items.First(i => i.ItemId == itemId);
        wishList.Items.Remove(item);
        _context.Update(wishList);
        await _context.SaveChangesAsync();

        return Ok();
    }
}