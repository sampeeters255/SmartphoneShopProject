using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class Smartphone
  {
    public int SmartphoneId { get; set; }
    public decimal Prijs { get; set; }
    public string Model { get; set; }

    public Merk Merk { get; set; }
  }
}
