using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreMvcExamApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Display(Name = "Image : ")]
        public string? ProductImage { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
		public IFormFile? ImageUpload { get; set; }

        public IList<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();


    }
}
