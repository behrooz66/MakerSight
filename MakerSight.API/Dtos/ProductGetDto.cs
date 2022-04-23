namespace MakerSight.API.Dtos
{
    public record ProductGetDto
    {
        public Guid Id { get; init; }
        public Guid? ParentId { get; init; }
        public string Title { get; init; } = default!;
        public decimal Price { get; init; }
        public string ImageUrl { get; init; } = default!;
        public BrandGetDto Brand { get; init; } = default!;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public string CreatedBy { get; init; } = default!;
        public string UpdatedBy { get; init; } = default!;
    }
}