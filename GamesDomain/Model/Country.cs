using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDomain.Model;

public partial class Country
{
    public int Id { get; set; }

    [Display(Name="Країна")]
    [Required(ErrorMessage="Поле має бути заповнене")]
    [MaxLength(50, ErrorMessage = "Не може перевищувати 50 символів")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
}
