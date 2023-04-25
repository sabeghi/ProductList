using System;
using System.Collections.Generic;

#nullable disable

namespace ProductCrud.Models
{
    public partial class ProductAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short? Type { get; set; }
        public int ProductId { get; set; }

        public virtual Product IdNavigation { get; set; }
    }
}
