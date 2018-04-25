using System;

namespace Bookshelf
{
    public sealed class AuthorBook
    {
        public Author Author { get; set; }
        public Book Book { get; set; }
        public Guid IdAuthor { get; set; }
        public Guid IdBook { get; set; }
    }
}