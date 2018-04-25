using System;

namespace Bookshelf
{
    public abstract class BaseObject
    {
        public Guid IdObject { get; set; }
        public Int32 Uid { get; set; }
        public Int32 Gid { get; set; }
        public Int16 Permission { get; set; }
    }
}