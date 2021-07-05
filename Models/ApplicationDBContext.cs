using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _Books.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}