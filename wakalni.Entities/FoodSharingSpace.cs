using System;
using System.Collections.Generic;
using System.Text;

namespace wakalni.Entities
{
    public class FoodSharingSpace : BaseEntity
    {
        public FoodSharingSpace()
        {
            Items = new List<Item>();
        }
        public string Name { get; set; }
        public string CoverPath { get; set; }

        public ApplicationUser Owner { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
