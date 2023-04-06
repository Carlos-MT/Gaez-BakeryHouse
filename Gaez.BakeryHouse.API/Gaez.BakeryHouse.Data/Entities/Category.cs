using System;
using System.Collections.Generic;

namespace Gaez.BakeryHouse.Data.Entities
{
    public partial class Category
    {
        public Category()
        {
            ProductBelongsToCategories = new HashSet<ProductBelongsToCategory>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductBelongsToCategory> ProductBelongsToCategories { get; set; }
    }
}
