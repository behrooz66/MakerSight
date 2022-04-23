namespace MakerSight.API.Dtos
{
    public record ProductCreateDto
    {
        public Guid? ParentId { get; init; }
        public string Title { get; init; } = default!;
        public decimal Price { get; init; }
        public string ImageUrl { get; init; } = default!;
    }
}