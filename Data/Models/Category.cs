using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Models
{
   [Table("Category")]
    public class Category
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriesID { get; set; }
        [StringLength(50)]
        public string CategorySeri { get; set; }
        public string CategoryName { get; set; }
        public string CategoryInfo { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}