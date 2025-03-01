using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDomain.Model;

public partial class Genre
{
    public int Id { get; set; }

    [Display(Name = "Жанр")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [MaxLength(15, ErrorMessage = "Не може перевищувати 15 символів")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
