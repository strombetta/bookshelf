using System;

namespace Bookshelf
{
    public class Author : BaseObject
    {
        public Guid IdAuthor { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
    }
}