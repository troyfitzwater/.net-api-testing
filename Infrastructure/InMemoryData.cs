using Core;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class InMemoryData : IQuotesData
    {
        readonly List<Quote> quotes;

        public InMemoryData()
        {
            quotes = new List<Quote>()
            {
                new Quote { Id = Guid.NewGuid(), Content = "test 1", CreatedBy = "troy" },
                new Quote { Id = Guid.NewGuid(), Content = "test 2", CreatedBy = "steve" },
                new Quote { Id = Guid.NewGuid(), Content = "test 3", CreatedBy = "grat" },
            };
        }

        public IEnumerable<Quote> GetAll()
        {
            return quotes;
        }

        public Quote GetQuote(Guid quoteId)
        {
            return quotes.Find(quote => quote.Id == quoteId);
        }

        public Quote AddQuote(Quote quoteToAdd)
        {
            quotes.Add(quoteToAdd);
            return quoteToAdd;
        }

    }
}
