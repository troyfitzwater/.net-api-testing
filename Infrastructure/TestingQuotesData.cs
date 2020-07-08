using Core;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infrastructure
{
    public class TestingQuotesData : IQuotesData
    {
        private readonly QuoteContext context;
        
        public TestingQuotesData(QuoteContext _context)
        {
            context = _context;
        }

        public Quote AddQuote(Quote quoteToAdd)
        {
            context.Quotes.Add(quoteToAdd);
            context.SaveChanges();

            return quoteToAdd;
        }

        public IEnumerable<Quote> GetAll()
        {
            var query = from quotes in context.Quotes
                        orderby quotes.Id descending
                        select quotes;

            return query;
        }

        public Quote GetQuote(int quoteId)
        {
            return context.Quotes.Find(quoteId);
        }
    }
}
