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
    public class PublishersController : Controller
    {
        private readonly BookshelfContext _context;

        public PublishersController(BookshelfContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Add([FromBody]Publisher publisher)
        {
            if (publisher == null) return BadRequest();
            if (!_context.Publishers.Select(e => e.Name == publisher.Name).Any())
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return Ok();
            }
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return _context.Publishers.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var publisher = _context.Publishers.FirstOrDefault(e => e.PublisherId == id);
            if (publisher == null) return NotFound();
            else return new ObjectResult(publisher);
        }

        [HttpGet("{id}/Books")]
        public IActionResult GetBooks(Guid id)
        {
            var publisher = _context.Publishers.Include(e => e.Books).FirstOrDefault(e => e.PublisherId == id);
            if (publisher == null) return NotFound();
            else return Ok(publisher.Books.ToList());
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var publisher = _context.Publishers.FirstOrDefault(e => e.PublisherId == id);
            if (publisher == null) return NotFound();
            else
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
                return Ok();
            }
        }

    }
}
