using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDomain.Model;

public partial class Stock
{
    [Display(Name = "Гра")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public int GameId { get; set; }

    [Display(Name = "Магазин")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public int ShopId { get; set; }

    [Display(Name = "Кількість")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [Range(0, int.MaxValue, ErrorMessage = "Значення має бути додатнім")]
    public int Quantity { get; set; }

    [Display(Name = "Ціна")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [Range(0, int.MaxValue, ErrorMessage ="Значення має бути додатнім")]
    public int Price { get; set; }

    [Display(Name = "Гра")]
    public virtual Game? Game { get; set; } = null!;

    [Display(Name = "Магазин")]
    public virtual Shop? Shop { get; set; } = null!;
}
