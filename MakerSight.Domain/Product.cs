
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakerSight.Domain
{
    public class Product : BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;

        [Required]
        public Guid BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; } = default!;
    }
}