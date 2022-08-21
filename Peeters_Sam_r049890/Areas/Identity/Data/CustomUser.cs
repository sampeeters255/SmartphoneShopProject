using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Areas.Identity.Data
{
  public class CustomUser: IdentityUser
  {
    [PersonalData]
    public string Naam { get; set; }
    [PersonalData]
    public string Voornaam { get; set; }
  }
}
