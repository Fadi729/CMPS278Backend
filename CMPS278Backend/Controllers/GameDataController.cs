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

    [HttpPost("list")]
    public async Task<ActionResult<GameData>> PostGameDataList(IEnumerable<GameDataDTO> gameDataList)
    {
        if (_context.GameData == null)
        {
            return Problem("Entity set 'CMPS278DataContext.GameData'  is null.");
        }

        _context.GameData.AddRange(gameDataList.Select(app => app.ToGameData()));
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            // if (ApplicationDataExists(applicationDataList.AppId))
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
}