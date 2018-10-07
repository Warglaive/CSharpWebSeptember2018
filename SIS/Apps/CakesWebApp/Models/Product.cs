using System.Collections.Generic;

namespace CakesWebApp.Models
{
    public class Product : BaseModel<int>
    {
        public Product()
        {
            this.Orders = new HashSet<OrderProduct>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public virtual ICollection<OrderProduct> Orders { get; set; }
    }
}