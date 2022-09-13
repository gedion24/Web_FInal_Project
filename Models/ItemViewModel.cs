using ElectronicsStore.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicsStore.Models
{
    public class ItemViewModel
    {

        [Key]
        public Guid ItemId { get; set; }

        //Navigation property
        [ForeignKey("Sellers")]
        public Guid SellerId { get; set; }


        // The '?' means the value set on these variables is `NULL`
        // [Required] means the value set on these variables is `NOT NULL`
        //[Required]
        //public string Id { get; set; }
        //[ForeignKey("Id")]
        //public virtual ElectronicsStoreUser electronicsStoresUser { get; set; }


        [Required]
        [DisplayName("Upload File")]
        public string? ItemImage { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        [StringLength(10)]
        public string? ItemStatus { get; set; }
        public string? ItemDescription { get; set; }

        
        public string? Condition { get; set; }
        public long? Amount { get; set; }
        public long? PricePerItem { get; set; }
        public string brand { get; set; }
    }
}
