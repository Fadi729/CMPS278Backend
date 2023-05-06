using System.Security.Claims;
using CMPS278Backend.Extensions;
using CMPS278Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMPS278Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HistoryController : ControllerBase
{
    readonly CMPS278DataContext _context;

    public HistoryController(CMPS278DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<History>> GetHistory()
    {
        History? history = await _context.History.FindAsync(HttpContext.GetUserId());

        if (history == null)
        {
            return NotFound();
        }

        return Ok(history);
    }

    // POST: api/History
    [HttpPost]
    public async Task<ActionResult> AddItemToHistory(HistoryItem item)
    {
        string userId = HttpContext.GetUserId();
        History? history = await _context.History.FindAsync(userId);

        if (history == null)
        {
            history = new History
            {
                UserId = userId,
                Items = new List<HistoryItem>()
            };
            _context.History.Add(history);

        }

        if (history.Items.Count == 24 )
        {
            history.Items.RemoveAt(0);
        }


        history.Items.Add(item);
        _context.Update(history);
        await _context.SaveChangesAsync();

        return Ok();
    }

    // DELETE: api/History
    [HttpDelete]
    public async Task<ActionResult> RemoveItemFromHistory(string itemId)
    {
        History? history = await _context.History.FindAsync(HttpContext.GetUserId());

        if (history == null)
        {
            return NotFound();
        }

        HistoryItem item = history.Items.First(i => i.ItemId == itemId);
        history.Items.Remove(item);
        _context.Update(history);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
