using System.ComponentModel.DataAnnotations;

namespace MUSACAWEbApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [MaxLength(12)]
        public int Barcode { get; set; }

        public string Picture { get; set; }
    }
}
