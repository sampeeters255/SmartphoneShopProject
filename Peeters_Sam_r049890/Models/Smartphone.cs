using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class Smartphone
  {
    [Key]
    public int SmartphoneId { get; set; }
    public decimal Prijs { get; set; }
    public string Model { get; set; }
    [Display(Name = "Datum Aangemaakt")]
    [DataType(DataType.Date)]
    public DateTime AangemaaktDatum { get; set; }
    public int MerkId { get; set; }
    [ForeignKey("MerkId")]
    public Merk Merk { get; set; }
  }
}
