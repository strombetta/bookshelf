using System;
using System.Collections.Generic;

namespace Bookshelf
{
    public class Book : BaseObject
    {
        public ICollection<AuthorBook> Authors { get; set; }
        public Guid IdBook {get;set;}
        public String Title { get; set; }
        public String Subtitle {get;set;}
        public Guid Publisher { get; set; }
        public String Ddcn { get; set; }
        public String Isbn10 { get; set; }
        public String Isbn13 { get; set; }
        public Int16 Pages { get; set; }
    }
}
