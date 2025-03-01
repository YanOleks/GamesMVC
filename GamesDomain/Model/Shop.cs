using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDomain.Model;

public partial class Shop
{
    public int Id { get; set; }

    [Display(Name = "Магазин")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [MaxLength(15, ErrorMessage = "Не може перевищувати 15 символів")]
    public string Name { get; set; } = null!;

    [Display(Name = "Розташування")]
    [MaxLength(50, ErrorMessage = "Не може перевищувати 50 символів")]
    public string? Location { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
