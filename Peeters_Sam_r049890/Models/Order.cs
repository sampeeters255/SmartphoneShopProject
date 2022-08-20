using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; }

    public int Aantal { get; set; }
    public int KlantId { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }

  }
}
