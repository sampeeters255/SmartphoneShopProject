using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class OrderItem
  {
    [Key]
    public int OrderItemId { get; set; }
    public int Aantal { get; set; }
    public Decimal Prijs { get; set; }
    public int SmartphoneId { get; set; }
    [ForeignKey("SmartphoneId")]
    public Smartphone Smartphone { get; set; }
    public int OrderId { get; set; }
    [ForeignKey("OrderId")]
    public Order Order { get; set; }
  }
}
