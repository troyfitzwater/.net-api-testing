using Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options) : base(options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
