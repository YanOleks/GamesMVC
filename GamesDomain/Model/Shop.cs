using System;
using System.Collections.Generic;

namespace GamesDomain.Model;

public partial class Shop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
