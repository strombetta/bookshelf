using Bookshelf;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bookshelf.Api.Models
{
    public class BookshelfContext : DbContext
    {
        public BookshelfContext(DbContextOptions<BookshelfContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(e => e.IdAuthor);
            modelBuilder.Entity<AuthorBook>().HasKey(e => new {e.IdAuthor, e.IdBook});
            modelBuilder.Entity<Book>().HasKey(e => e.IdBook);
            modelBuilder.Entity<Publisher>().HasKey(e => e.IdPublisher);
        }

        public DbSet<Book> Books { get; set; }
    }
}