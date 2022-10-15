using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicsStore.Models;

using ElectronicsStore.Areas.Identity.Data;
using System.Web;

public class Items
{




    
    [Key]
    public Guid ItemId { get; set; }

    public string ItemName { get; set; }

   

    [Required]
    public string Id { get; set; }
    [ForeignKey("Id")]
    public virtual ElectronicsStoreUser electronicsStoresUser { get; set; }


    // The '?' means the value set on these variables is `NULL`
    // [Required] means the value set on these variables is `NOT NULL`



    [Required]
    [DisplayName("ItemImage")]
    public string? ItemImage { get; set; }

    [NotMapped]
    [DisplayName("ItemImage")]
    public IFormFile ImageFile { get; set; }


    [StringLength(10)]
    public string? ItemStatus { get; set; }
    public string? ItemDescription { get; set; }

    
    public string? Condition { get; set; }
    public long? Amount { get; set; }
    public long? PricePerItem { get; set; }
    public string brand { get; set; }

    public string SellerEmail { get; set; }
    public string SellerPhonenumber{ get; set; }





}
