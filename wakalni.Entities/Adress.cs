using System;
using System.Collections.Generic;
using System.Text;

namespace wakalni.Entities
{
    public class Adress : BaseEntity
    {

        public int Number { get; set; }
        public string Appartment { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
    }
}
