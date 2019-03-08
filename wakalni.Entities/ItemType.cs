using System;
using System.Collections.Generic;
using System.Text;

namespace wakalni.Entities
{
    public class ItemType : BaseEntity
    {
        public ItemType()
        {
            Items = new List<Item_ItemType>();
        }
        public string Label { get; set; }
        public string NormalizedLabel { get; set; }

        public ICollection<Item_ItemType> Items { get; set; }
    }
}
