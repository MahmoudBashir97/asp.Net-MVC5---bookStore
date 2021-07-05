using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using _Books.Models;


namespace _Books.ViewModels
{
    public class BookFromViewModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        [MaxLength(128)]
        public string Author { get; set; }

        [Required]
        [MaxLength(128)]
        public string Description { get; set; }

        [Display(Name ="Category")]
        public byte CategoryId { get; set; }

        public IEnumerable<Category> categories { get; set; }
    }
}