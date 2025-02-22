using System;
using System.Collections.Generic;

namespace GamesDomain.Model;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
}
