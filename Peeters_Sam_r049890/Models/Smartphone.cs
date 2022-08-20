using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    [Required]
    public decimal Prijs { get; set; }
    [Required]
    public string Model { get; set; }
    [Display(Name = "Datum Aangemaakt")]
    [DataType(DataType.Date)]
    public DateTime AangemaaktDatum { get; set; }
    public string Merk { get; set; }

    [DisplayName("Image Name")]
    public string ImageName { get; set; }
    [NotMapped]
    [DisplayName("Upload File")]
    public IFormFile ImageFile { get; set; }
    public string ImageUrl { get; set; }



    //public int MerkId { get; set; }
    //[ForeignKey("MerkId")]
    //public Merk Merk { get; set; }
  }
}
