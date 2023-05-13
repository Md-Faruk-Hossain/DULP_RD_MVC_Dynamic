using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DUPL_RD.Models
{
    public class BookDbContext:DbContext
    {
        public BookDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookDbContext>());
        }
        public DbSet<Book> Books { get; set; }
    }
}