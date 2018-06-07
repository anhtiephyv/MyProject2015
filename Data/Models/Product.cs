using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [StringLength(50)]
        public string ProductSeri { get; set; }
        public string ProductName { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }
        public virtual Category Category { get; set; }
    }
}