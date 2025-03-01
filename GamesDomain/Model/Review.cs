using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDomain.Model;

public partial class Review
{
    public int Id { get; set; }

    [Display(Name = "Гра")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public int GameId { get; set; }

    [Display(Name = "Оцінка")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public int Rating { get; set; }

    [Display(Name = "Відгук")]
    public string? Review1 { get; set; }

    [Display(Name = "Гра")]
    public virtual Game Game { get; set; } = null!;
}
