using CMPS278Backend.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMPS278Backend.Models;
using CMPS278Backend.ModelsDTO;

namespace CMPS278Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationDataController : ControllerBase
{
    readonly CMPS278DataContext _context;

    public ApplicationDataController(CMPS278DataContext context)
    {
        _context = context;
    }

    // GET: api/ApplicationData
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationDataDTO>>> GetApplicationsData()
    {
        if (_context.ApplicationData == null)
        {
            return NotFound();
        }

        return await _context.ApplicationData.Include(data => data.Reviews).Select(app => app.ToApplicationDataDTO())
                             .ToListAsync();
    }

    // POST: api/ApplicationData
    [HttpPost]
    public async Task<ActionResult<ApplicationData>> PostApplicationData(ApplicationDataDTO applicationData)
    {
        if (_context.ApplicationData == null)
        {
            return Problem("Entity set 'CMPS278DataContext.ApplicationData'  is null.");
        }

        _context.ApplicationData.Add(applicationData.ToApplicationData());
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (ApplicationDataExists(applicationData.AppId))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("GetApplicationsData", new { id = applicationData.AppId }, applicationData);
    }

    // POST: api/ApplicationData/list
    [HttpPost("list")]
    public async Task<ActionResult<ApplicationData>> PostApplicationDataList(IEnumerable<ApplicationDataDTO> applicationDataList)
    {
        if (_context.ApplicationData == null)
        {
            return Problem("Entity set 'CMPS278DataContext.ApplicationData'  is null.");
        }

        _context.ApplicationData.AddRange(applicationDataList.Select(app => app.ToApplicationData()));
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
            //     throw;
            // }
        }

        return NoContent();
    }

    // DELETE: api/ApplicationData/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplicationData(string id)
    {
        if (_context.ApplicationData == null)
        {
            return NotFound();
        }

        var applicationData = await _context.ApplicationData.FindAsync(id);
        if (applicationData == null)
        {
            return NotFound();
        }

        _context.ApplicationData.Remove(applicationData);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    bool ApplicationDataExists(string id)
    {
        return (_context.ApplicationData?.Any(e => e.AppId == id)).GetValueOrDefault();
    }
}