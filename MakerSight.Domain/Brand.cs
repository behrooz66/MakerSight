using System;
using System.ComponentModel.DataAnnotations;

namespace MakerSight.Domain
{
    public class Brand : BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;

        // this is a navigation property
        public virtual ICollection<Product> Products { get; set; }

        public Brand()
        {
            this.Products = new List<Product>();
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}