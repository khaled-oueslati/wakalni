using System;
using System.Collections.Generic;
using System.Text;

namespace wakalni.Application.Items.Models
{
    public class ItemsDetailModel
    {
        public IEnumerable<ItemDTO> Items { get; set; }

        public int totalNumber { get; set; }
        public int NextPage { get; set; }
    }
}
