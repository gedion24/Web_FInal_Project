using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsStore.Models;
using Microsoft.AspNetCore.Identity;

namespace ElectronicsStore.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ElectronicsStoreUser class
public class ElectronicsStoreUser : IdentityUser
{
  //  [Key]
  //// [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  //  public Guid SellerId { get; set; }
    //public ElectronicsStoreUser electronicsStoresUser { get; set; }

    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //[PersonalData]
  //  public Guid ItemId { get; set; }
  //[ForeignKey("ItemId")]
  //public virtual Items item { get; set; }
 
  //public Items item { get; set; }
    //[ForeignKey("Item")]
    [Required]
    public string SellerFname { get; set; }
    [Required]
    public string SellerLname { get; set; }
    
   // public string SellerImage { get; set; }
    [Required]
    public DateTime SDOB { get; set; }
    [Required]
    public string SUsername { get; set; }
    [Required]
    public string SPassword { get; set; }

    public List<Items> Items { get; set; }
}

