using Moq;
using System;
using System.Linq;

using Xunit;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using MakerSight.API.Infrastructure;
using MakerSight.API.Controllers;
using System.Threading.Tasks;
using MakerSight.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MakerSight.API.Tests;

public class ProductsControllerTests
{
    private readonly IServiceProvider serviceProvider;
    public ProductsControllerTests()
    {
        var services = new ServiceCollection();
        services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()), ServiceLifetime.Singleton);
        serviceProvider = services.BuildServiceProvider();
    }

    [Fact]
    public async Task GetAllBrandProducts_ReturnsCorrectProductCount_Success()
    {
        // arrange
        var mock = new Mock<ILogger<ProductsController>>();
        ILogger<ProductsController> logger = mock.Object;

        var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
        SeedDataCreator.AddSeedBrandsData(dbContext);
        SeedDataCreator.AddSeedProductsData(dbContext);
        var controller = new ProductsController(logger, dbContext);

        // act
        var result = await controller.GetAll(SeedDataCreator.BrandIds[0]);

        // assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public async Task Post_PriceTooLow_Returns400()
    {
        // arrange
        var mock = new Mock<ILogger<ProductsController>>();
        ILogger<ProductsController> logger = mock.Object;

        var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
        SeedDataCreator.AddSeedBrandsData(dbContext);
        var controller = new ProductsController(logger, dbContext);

        // act
        var dto = new ProductCreateDto
        {
            Price = 0.5m
        };
        var rawResult = await controller.Post(SeedDataCreator.BrandIds[0], dto);
        var result = rawResult as ObjectResult;

        // assert
        Assert.True(result is BadRequestObjectResult);
    }

    [Fact]
    public async Task Post_WrongBrandId_Returns400()
    {
        // arrange
        var mock = new Mock<ILogger<ProductsController>>();
        ILogger<ProductsController> logger = mock.Object;

        var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
        SeedDataCreator.AddSeedBrandsData(dbContext);
        var controller = new ProductsController(logger, dbContext);

        // act
        var dto = new ProductCreateDto
        {
            ParentId = null,
            Title = "Something",
            ImageUrl = "some/path",
            Price = 18.00m
        };
        var rawResult = await controller.Post(Guid.NewGuid(), dto);
        var result = rawResult as ObjectResult;

        // assert
        Assert.True(result is BadRequestObjectResult);
    }

    [Fact]
    public async Task Post_Success()
    {
        // arrange
        var mock = new Mock<ILogger<ProductsController>>();
        ILogger<ProductsController> logger = mock.Object;

        var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
        SeedDataCreator.AddSeedBrandsData(dbContext);
        SeedDataCreator.AddSeedProductsData(dbContext);
        var controller = new ProductsController(logger, dbContext);
        var initialProductCount = dbContext.Products.Count();

        // act
        var dto = new ProductCreateDto
        {
            ParentId = null,
            Title = "Something",
            ImageUrl = "some/path",
            Price = 18.00m
        };
        var rawResult = await controller.Post(SeedDataCreator.BrandIds[0], dto);

        var newProductCount = dbContext.Products.Count();

        // assert
        Assert.Equal(initialProductCount + 1, newProductCount);
    }
}