using CMPS278Backend.Extensions;
using CMPS278Backend.Models;
using CMPS278Backend.Models.Games;
using CMPS278Backend.ModelsDTO.GameDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMPS278Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameDataController : ControllerBase
{
    readonly CMPS278DataContext _context;

    public GameDataController(CMPS278DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDataDTO>>> GetGameData()
    {
        if (_context.GameData == null)
        {
            return NotFound();
        }

        return await _context.GameData.Include(data => data.Reviews).Select(game => game.ToGameDataDTO()).ToListAsync();
    }

    
    [HttpPost]
    public async Task<ActionResult<GameData>> PostGameData(GameDataDTO gameData)
    {
        if (_context.GameData == null)
        {
            return Problem("Entity set 'CMPS278DataContext.GameData'  is null.");
        }

        _context.GameData.Add(gameData.ToGameData());
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (GameDataExists(gameData.AppId))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("GetGameData", new { id = gameData.AppId }, gameData);
    }

    
    [HttpPost("list")]
    public async Task<ActionResult<GameData>> PostGameDataList(IEnumerable<GameDataDTO> gameDataList)
    {
        if (_context.GameData == null)
        {
            return Problem("Entity set 'CMPS278DataContext.GameData'  is null.");
        }

        _context.GameData.AddRange(gameDataList.Select(game => game.ToGameData()));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            // if (GameDataExists(gameDataList.AppId))
            // {
            //     return Conflict();
            // }
            // else
            // {
            throw;
            // }
        }

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGameData(string id)
    {
        if (_context.GameData == null)
        {
            return NotFound();
        }

        var gameData = await _context.GameData.FindAsync(id);
        if (gameData == null)
        {
            return NotFound();
        }

        _context.GameData.Remove(gameData);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    bool GameDataExists(string id)
    {
        return (_context.GameData?.Any(e => e.AppId == id)).GetValueOrDefault();
    }
}