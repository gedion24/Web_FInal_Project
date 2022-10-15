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
 
    [Required]
    public string SellerFname { get; set; }
    [Required]
    public string SellerLname { get; set; }
    
    [Required]
    public DateTime SDOB { get; set; }
    [Required]
    public string SUsername { get; set; }
    [Required]
    public string SPassword { get; set; }

    public List<Items> Items { get; set; }
}

