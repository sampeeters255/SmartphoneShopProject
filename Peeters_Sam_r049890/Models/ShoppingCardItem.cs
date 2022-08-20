using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class ShoppingCardItem
  {
    [Key]
    public int ShoppingCardItemId { get; set; }
    public Smartphone Smartphone { get; set; }
    public int Hoeveelheid { get; set; }
    public string ShoppingCardId { get; set; }
  }
}
