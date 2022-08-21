using Peeters_Sam_r049890.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class ApplicationUser : CustomUser
  {
    public int AppUserId { get; set; }
  }
}
