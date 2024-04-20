using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    #region CREATE
    [HttpPost] // CREATE
    public async Task<IActionResult> Subscribe(SubscriberEntity entity)
    {
        if (ModelState.IsValid)
        {
            if (await _context.Subscribers.AnyAsync(x => x.Email == entity.Email))
            {
                return Conflict();
            }
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return BadRequest();
    }
    #endregion

    #region READ
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subscribers = await _context.Subscribers.ToListAsync();
        if (subscribers.Count != 0)
        {
            return Ok(subscribers);
        }
        return NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        if (subscriber != null)
        {
            return Ok(subscriber);
        }
        return NotFound();

    }
    #endregion

    #region UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOne(int id, string email)
    {
        var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        if (subscriber != null)
        {
            subscriber.Email = email;
            _context.Subscribers.Update(subscriber);
            await _context.SaveChangesAsync();

            return Ok(subscriber);
        }
        return NotFound();
    }
    #endregion

    #region DELETE
    [HttpDelete("{email}")]
    public async Task<IActionResult> DeleteOne(string email)
    {
        var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
        if (subscriber != null)
        {
            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();

            return Ok();
        }
        return NotFound();
    }
    #endregion
}
