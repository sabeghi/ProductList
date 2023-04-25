using System;
using System.Collections.Generic;

#nullable disable

namespace ProductCrud.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }
        public string Description { get; set; }
        public bool? Presentable { get; set; }
        public int Category { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
