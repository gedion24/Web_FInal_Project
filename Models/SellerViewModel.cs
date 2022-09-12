using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ElectronicsStore.Models
{
    public class SellerViewModel
    {
        [StringLength(15)]     // The maximum length of a valid phone number is 15 characters 
        public string? SellerPhone { get; set; }

        [StringLength(320)]    // The maximum length of a valid email address is 320 characters 
        public string? SellerEmail { get; set; }

        [Required]
        public string? SellerImage { get; set; }

        //   public HttpPostFileBase Imagefile { get; set; }

        //[StringLength(10)]
        //public string? ItemStatus { get; set; }
        //public string? ItemDescription { get; set; }

        //[StringLength(10)]
        //public string? Condition { get; set; }
        //public long? Amount { get; set; }
        //public long? PricePerItem { get; set; }
        //public string brand { get; set; }
    }
}
