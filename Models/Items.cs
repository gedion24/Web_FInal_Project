using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicsStore.Models
{
    public class Items
    {




        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[ForeignKey("ItemId")]
        [Key]
        public Guid ItemId { get; set; }

        //Navigation property   [Key, Column(Order = 0),ForeignKey("SellerId")]   [ForeignKey("SellerId")]
        [ForeignKey("Sellers")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public Guid SellerId { get; set; }


        // The '?' means the value set on these variables is `NULL`
        // [Required] means the value set on these variables is `NOT NULL`

       
       
        [Required]
        [DisplayName("Upload File")]
        public string? ItemImage { get; set; }
    //    [NotMapped]
    //    [DisplayName("Upload File")]
    ////    public HttpPostedFileBase ImageFile { get; set; }

        [StringLength(10)]
        public string? ItemStatus { get; set; }
        public string? ItemDescription { get; set; }

        
        public string? Condition { get; set; }
        public long? Amount { get; set; }
        public long? PricePerItem { get; set; }
        public string brand { get; set; }





    }
}
