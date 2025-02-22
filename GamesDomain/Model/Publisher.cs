using System;
using System.Collections.Generic;

namespace GamesDomain.Model;

public partial class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CountryOfOrigin { get; set; }

    public virtual Country CountryOfOriginNavigation { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
