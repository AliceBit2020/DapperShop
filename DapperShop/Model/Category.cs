using System;
using System.Collections.Generic;

namespace DapperShop.Model;

public partial class Category
{
    public int Id { get; set; } = 0;

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
