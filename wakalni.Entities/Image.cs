using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace wakalni.Entities
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Principal { get; set; }
        public int ImageOrder { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}