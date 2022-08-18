using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class Merk
  {
    public int MerkId { get; set; }
    public string Merknaam { get; set; }
    public string Herkomst { get; set; }

    public List<Smartphone> Smartphones { get; set; }
  }
}
