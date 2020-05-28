using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesData _context;

        public QuotesController(IQuotesData context)
        {
            _context = context;
        }

        // GET: /quotes
        [HttpGet]
        public IEnumerable<Quote> GetQuotes()
        {
            return _context.GetAll();
        }

        // GET: /quotes/1
        [HttpGet("{id}")]
        public ActionResult<Quote> GetQuote(Guid id)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            Quote quote = _context.GetQuote(id);

            if (quote == null) {
                return NotFound();

            }

            return Ok(quote);
        }

        [HttpPost]
        public ActionResult<Quote> AddQuote(Quote quoteToAdd)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            quoteToAdd.Id = Guid.NewGuid();
            _context.AddQuote(quoteToAdd);

            return CreatedAtAction(nameof(GetQuote), new { id = quoteToAdd.Id }, quoteToAdd);
        }
    }
}
