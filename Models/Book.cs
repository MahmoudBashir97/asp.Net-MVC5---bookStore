using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _Books.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(128)]
        public string Author { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
       
        public byte CategoryId { get; set; }

        public Category category { get; set; } // navigation property

        public DateTime AddedOn { get; set; }

        public Book() {
            AddedOn = DateTime.Now;
        }
    }
}