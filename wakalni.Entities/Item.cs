using System;
using System.Collections.Generic;
using System.Text;

namespace wakalni.Entities
{
    public class Item : BaseEntity
    {
        public Item()
        {
            ItemTypes = new List<Item_ItemType>();
            Images = new List<Image>();
        }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Image> Images { get; set; }

        public virtual List<Item_ItemType> ItemTypes { get; set; }
        public FoodSharingSpace SharingSpace { get; set; }
    }

    public class Item_ItemType
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int ItemTypeId { get; set; }
        public virtual ItemType ItemType { get; set; }

    }
}
