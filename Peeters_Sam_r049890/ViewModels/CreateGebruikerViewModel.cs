using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Peeters_Sam_r049890.ViewModels
{
  public class CreateGebruikerViewModel
  {
    public string Naam { get; set; }
    public string Voornaam { get; set; }
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}
