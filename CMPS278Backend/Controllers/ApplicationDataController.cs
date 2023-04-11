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
    public async Task<ActionResult<IEnumerable<ApplicationData>>> GetApplicationData()
    {
        if (_context.ApplicationData == null)
        {
            return NotFound();
        }

        return await _context.ApplicationData.ToListAsync();
    }

    // GET: api/ApplicationData/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationData>> GetApplicationData(string id)
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

        return applicationData;
    }

    // PUT: api/ApplicationData/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutApplicationData(string id, ApplicationData applicationData)
    {
        if (id != applicationData.AppId)
        {
            return BadRequest();
        }

        _context.Entry(applicationData).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ApplicationDataExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/ApplicationData
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        return CreatedAtAction("GetApplicationData", new { id = applicationData.AppId }, applicationData);
    }

    [HttpPost("list")]
    public async Task<ActionResult<ApplicationData>> PostApplicationDataList(
        IEnumerable<ApplicationDataDTO> applicationDataList)
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

    private bool ApplicationDataExists(string id)
    {
        return (_context.ApplicationData?.Any(e => e.AppId == id)).GetValueOrDefault();
    }
}