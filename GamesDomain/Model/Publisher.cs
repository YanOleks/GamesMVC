using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDomain.Model;

public partial class Publisher
{
    public int Id { get; set; }

    [Display(Name = "Видавець")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    [MaxLength(15, ErrorMessage = "Не може перевищувати 15 символів")]
    public string Name { get; set; } = null!;

    [Display(Name = "Країна походження")]
    [Required(ErrorMessage = "Поле має бути заповнене")]
    public int CountryOfOrigin { get; set; }

    [Display(Name = "Країна походження")]
    public virtual Country? CountryOfOriginNavigation { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
