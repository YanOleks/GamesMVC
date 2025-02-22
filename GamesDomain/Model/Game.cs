using System;
using System.Collections.Generic;

namespace GamesDomain.Model;

public partial class Game
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int PublisherId { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
