using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Books.Models
{
    //[Table("Categories")]//here u can set a name for this model that will be stored in db
    [Table("FehresList")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string name { get; set; }
        public bool isActive { get; set; }
    }
}