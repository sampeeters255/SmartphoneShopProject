using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.ViewModels
{
  public class SmartphoneCreateViewModel
  {
    public string Model { get; set; }
    public Decimal Prijs { get; set; }
    public int MerkId { get; set; }
    public DateTime AangemaaktDatum { get; set; }
  }
}
