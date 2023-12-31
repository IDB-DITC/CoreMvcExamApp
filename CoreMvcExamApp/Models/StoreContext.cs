using Microsoft.EntityFrameworkCore;

namespace CoreMvcExamApp.Models
{
	public class StoreContext:DbContext
	{


        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        public StoreContext(DbContextOptions opt):base(opt)
        {
            
        }


    }
}
