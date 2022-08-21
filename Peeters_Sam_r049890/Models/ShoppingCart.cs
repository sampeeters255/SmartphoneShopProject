using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Peeters_Sam_r049890.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Models
{
  public class ShoppingCart
  {
    public int ShoppingCartId { get; set; }
    [ForeignKey("smartphoneId")]
    [ValidateNever]
    public int SmartphoneId { get; set; }    
    public Smartphone Smartphone { get; set; }
    public int Hoeveelheid { get; set; }
    [ForeignKey("UserId")]
    [ValidateNever]
    public string UserId { get; set; }    
    public CustomUser CustomUser { get; set; }
  }
}
