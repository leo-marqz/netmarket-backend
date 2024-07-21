
using DOMAIN.Common;
//using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
