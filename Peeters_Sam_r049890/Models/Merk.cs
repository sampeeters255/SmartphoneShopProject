using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class Merk
  {
    [Key]
    public int MerkId { get; set; }
    [Required(ErrorMessage = "Het veld 'Merknaam' moet altijd ingevuld zijn.")]
    public string Merknaam { get; set; }
    public string Herkomst { get; set; }

    //public ICollection<Smartphone> Smartphones { get; set; }
  }
}
