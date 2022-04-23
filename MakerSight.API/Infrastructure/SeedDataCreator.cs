using MakerSight.Domain;

namespace MakerSight.API.Infrastructure
{
    public static class SeedDataCreator
    {

        // just creating some hard coded IDs, which will be used for seeding in-memory data as well as facilitating testing
        public static Guid[] BrandIds = new Guid[] {
            Guid.Parse("17cff5bb-3f4c-4676-ab1b-a177fd9aca25"),
            Guid.Parse("78724c54-9f9b-4c0e-9d70-417f10a20f6c")
        };

        public static Guid[] ProductIds = new Guid[] {
            Guid.Parse("62afc0a5-4715-4f5a-a3a9-3654c3393298"),
            Guid.Parse("387b907a-f64e-4fa0-a98d-2016e1a08039"),
            Guid.Parse("00156bc7-7496-406c-bf77-f9ceb928bb74"),
            Guid.Parse("b1d5cb42-03c5-4bdc-8d8b-91d18727f261")
        };


        public static void AddSeedBrandsData(AppDbContext context)
        {
            var brand0 = new Brand
            {
                Id = BrandIds[0],
                Name = "Shike",
                CreatedAt = DateTime.Now,
                CreatedBy = "Seed Data Creator",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Seed Data Creator"
            };

            var brand1 = new Brand
            {
                Id = BrandIds[1],
                Name = "Adidas",
                CreatedAt = DateTime.Now,
                CreatedBy = "Seed Data Creator",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Seed Data Creator"
            };

            context.Brands.Add(brand0);
            context.Brands.Add(brand1);
            context.SaveChanges();
        }

        public static void AddSeedProductsData(AppDbContext context)
        {
            var product0 = new Product
            {
                Id = ProductIds[0],
                BrandId = BrandIds[0],
                Title = "Cool Shirt",
                ImageUrl = "path/to/hosted/image",
                ParentId = null,
                Price = 18.00m,
                CreatedAt = DateTime.Now,
                CreatedBy = "Seed Data Creator",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Seed Data Creator"
            };

            var product1 = new Product
            {
                Id = ProductIds[1],
                BrandId = BrandIds[0],
                Title = "Cool Pants",
                ImageUrl = "path/to/hosted/image",
                ParentId = ProductIds[0],
                Price = 25.50m,
                CreatedAt = DateTime.Now,
                CreatedBy = "Seed Data Creator",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Seed Data Creator"
            };

            var product2 = new Product
            {
                Id = ProductIds[2],
                BrandId = BrandIds[1],
                Title = "Nice Shirt",
                ImageUrl = "path/to/hosted/image",
                ParentId = null,
                Price = 32.75m,
                CreatedAt = DateTime.Now,
                CreatedBy = "Seed Data Creator",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Seed Data Creator"
            };

            var product3 = new Product
            {
                Id = ProductIds[3],
                BrandId = BrandIds[0],
                Title = "Awesome Shirt",
                ImageUrl = "path/to/hosted/image",
                ParentId = null,
                Price = 12.99m,
                CreatedAt = DateTime.Now,
                CreatedBy = "Seed Data Creator",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "Seed Data Creator"
            };

            context.Products.Add(product0);
            context.Products.Add(product1);
            context.Products.Add(product2);
            context.Products.Add(product3);
            context.SaveChanges();
        }

    }
}