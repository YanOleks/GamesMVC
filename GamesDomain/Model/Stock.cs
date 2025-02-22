using System;
using System.Collections.Generic;

namespace GamesDomain.Model;

public partial class Stock
{
    public int GameId { get; set; }

    public int ShopId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Shop Shop { get; set; } = null!;
}
