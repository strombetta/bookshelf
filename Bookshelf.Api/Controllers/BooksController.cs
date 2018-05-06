using Bookshelf;
using Bookshelf.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BookshelfContext _context;

        public BooksController(BookshelfContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _context.Books.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var book = _context.Books.FirstOrDefault(e => e.BookId == id);
            if(book == null) return NotFound();
            else return new ObjectResult(book);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Book book)
        {
            if(book == null) throw new ArgumentNullException(nameof(book));
            if(String.IsNullOrWhiteSpace(book.Title)) throw new ArgumentNullException(nameof(book));
            
            _context.Books.Add(book);
            _context.SaveChanges();
            return new OkResult();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
