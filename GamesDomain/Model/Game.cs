using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDomain.Model;

public partial class Game
{
    public int Id { get; set; }

    [Display(Name = "Гра")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [MaxLength(15, ErrorMessage = "Не може перевищувати 15 символів")]
    public string Name { get; set; } = null!;

    [Display(Name = "Видавець")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public int PublisherId { get; set; }

    [Display(Name = "Жанр")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public int GenreId { get; set; }

    [Display(Name = "Жанр")]
    public virtual Genre? Genre { get; set; } = null!;

    [Display(Name = "Видавець")]
    public virtual Publisher? Publisher { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
