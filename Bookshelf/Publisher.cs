using System;
using System.Collections.Generic;

namespace Bookshelf
{
    public class Publisher
    {
        public Publisher()
        {
            CreatedOn = DateTime.Now;
            UpdatedOn = CreatedOn;
            IsActive = true;
        }

        public Guid PublisherId { get; set; }
        public String Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Boolean IsActive { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}