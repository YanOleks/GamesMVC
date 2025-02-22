using System;
using System.Collections.Generic;

namespace GamesDomain.Model;

public partial class Review
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int Rating { get; set; }

    public string? Review1 { get; set; }

    public virtual Game Game { get; set; } = null!;
}
