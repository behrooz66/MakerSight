namespace MakerSight.API.Dtos
{
    public record BrandGetDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
    }
}