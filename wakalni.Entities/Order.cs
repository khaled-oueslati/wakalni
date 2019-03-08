using System;
using System.Collections.Generic;
using System.Text;

namespace wakalni.Entities
{
    public class Order : BaseEntity
    {
        public int Quantity { get; set; }
        public ICollection<Item> Items { get; set; }
        public ApplicationUser Purchaser { get; set; }
        public ApplicationUser Seller { get; set; }


    }
}
