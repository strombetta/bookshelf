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
            modelBuilder.Entity<AuthorBook>().HasKey(e => new { e.IdAuthor, e.IdBook });

            // Book model.
            modelBuilder.Entity<Book>().HasKey(e => e.BookId);
            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId);

            // Publisher model.
            modelBuilder.Entity<Publisher>().HasKey(e => e.PublisherId);
            modelBuilder.Entity<Publisher>().HasMany(p => p.Books).WithOne(b => b.Publisher);

            //modelBuilder.Entity<Book>().HasOne(p => p.Publisher).WithMany(b => b.Books).HasForeignKey(p => p.IdBook);
            //modelBuilder.Entity<Publisher>().Property(e => e.CreatedOn).HasDefaultValueSql("CONVERT(date, GETDATE())");
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}