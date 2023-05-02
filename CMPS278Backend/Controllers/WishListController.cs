using System.Security.Claims;
using CMPS278Backend.Extensions;
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
        WishList? wishList = await _context.WishList.FindAsync(HttpContext.GetUserId());

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
        string userId = HttpContext.GetUserId();
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
        _context.Update(wishList);
        await _context.SaveChangesAsync();

        return Ok();
    }

    // DELETE: api/WishList
    [HttpDelete]
    public async Task<ActionResult> RemoveItemFromWishList(string itemId)
    {
        WishList? wishList = await _context.WishList.FindAsync(HttpContext.GetUserId());

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