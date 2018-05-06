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
    public class AuthorsController : Controller
    {
        private readonly BookshelfContext _context;

        public AuthorsController(BookshelfContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _context.Authors.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var author = _context.Authors.FirstOrDefault(e => e.IdAuthor == id);
            if(author == null) return NotFound();
            else return new ObjectResult(author);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Author author)
        {
            if(author == null) throw new ArgumentNullException(nameof(author));
            
            _context.Authors.Add(author);
            _context.SaveChanges();
            return new OkResult();
        }
    }
}
