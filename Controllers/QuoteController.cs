//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PA3_jiya.Models;
//using PA3_jiya.Data;

//namespace PA3_jiya.Controllers;

//[Route("api/quotes")]
//[ApiController]
//public class QuoteController(QuoteContext context) : ControllerBase
//{
//    private readonly QuoteContext _context = context;

//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
//    {
//        return await _context.Quotes.Include(q => q.Tags).ToListAsync();
//    }

//    [HttpPost]
//    public async Task<ActionResult<Quote>> AddQuote([FromBody] Quote quote)
//    {
//        _context.Quotes.Add(quote);
//        await _context.SaveChangesAsync();
//        return CreatedAtAction(nameof(GetQuotes), new { id = quote.Id }, quote);
//    }

//    [HttpPut("{id}/like")]
//    public async Task<IActionResult> LikeQuote(int id)
//    {
//        var quote = await _context.Quotes.FindAsync(id);
//        if (quote is null) return NotFound();

//        quote.Likes++;
//        await _context.SaveChangesAsync();
//        return Ok(quote);
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PA3_jiya.Models;
using PA3_jiya.Data;

namespace PA3_jiya.Controllers;

[Route("api/quotes")]
[ApiController]
public class QuoteController : ControllerBase
{
    private readonly QuoteContext _context;

    public QuoteController(QuoteContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
    {
        return await _context.Quotes.Include(q => q.Tags).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Quote>> AddQuote([FromBody] Quote quote)
    {
        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetQuotes), new { id = quote.Id }, quote);
    }

    [HttpPut("{id}/like")]
    public async Task<IActionResult> LikeQuote(int id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        if (quote is null) return NotFound();

        quote.Likes++;
        await _context.SaveChangesAsync();
        return Ok(quote);
    }

    [HttpPost("{id}/tags")]
    public async Task<IActionResult> AssignTag(int id, [FromBody] Tag tag)
    {
        var quote = await _context.Quotes.Include(q => q.Tags).FirstOrDefaultAsync(q => q.Id == id);
        if (quote == null) return NotFound();

        var existingTag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tag.Name);
        if (existingTag == null)
        {
            existingTag = new Tag { Name = tag.Name };
            _context.Tags.Add(existingTag);
        }

        if (!quote.Tags.Contains(existingTag))
        {
            quote.Tags.Add(existingTag);
        }

        await _context.SaveChangesAsync();
        return Ok(quote);
    }

}
