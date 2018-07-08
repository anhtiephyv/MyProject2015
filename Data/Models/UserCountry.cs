using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Models
{
    [Table("UserCountry")]
    public class UserCountry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string CountryId { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<Country> Country { get; set; }
    }
}
