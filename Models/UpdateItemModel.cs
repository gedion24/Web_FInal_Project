﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicsStore.Models
{
    public class UpdateItemModel
    {
        [Key]
        public Guid ItemId { get; set; }

        //Navigation property
        [ForeignKey("Sellers")]
        public Guid SellerId { get; set; }


        // The '?' means the value set on these variables is `NULL`
        // [Required] means the value set on these variables is `NOT NULL`

        
        [Required]

        public string? ItemImage { get; set; }

        [StringLength(10)]
        public string? ItemStatus { get; set; }
        public string? ItemDescription { get; set; }

        
        public string? Condition { get; set; }
        public long? Amount { get; set; }
        public long? PricePerItem { get; set; }
        public string brand { get; set; }
    }
}