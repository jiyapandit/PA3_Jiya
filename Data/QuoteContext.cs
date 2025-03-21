using Microsoft.EntityFrameworkCore;
using PA3_jiya.Models;

namespace PA3_jiya.Data;

public class QuoteContext(DbContextOptions<QuoteContext> options) : DbContext(options)
{
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Tag> Tags { get; set; }
}
