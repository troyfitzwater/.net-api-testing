using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces
{
    public interface IQuotesData
    {
        IEnumerable<Quote> GetAll();
        Quote GetQuote(int quoteId);
        Quote AddQuote(Quote quoteToAdd);
    }
}
