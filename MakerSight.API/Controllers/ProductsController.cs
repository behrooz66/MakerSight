using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MakerSight.API.Infrastructure;
using MakerSight.API.Dtos;
using Microsoft.EntityFrameworkCore;
using MakerSight.Domain;

namespace MakerSight.API.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly AppDbContext _context;
        public ProductsController(
            ILogger<ProductsController> logger,
            AppDbContext context
        )
        {
            this._logger = logger;
            this._context = context;
        }

        // GET: /brand/{brandId}/products
        // returns all products for a specific brand
        [HttpGet("brand/{brandId}/products")]
        public async Task<IEnumerable<ProductGetDto>> GetAll(Guid brandId)
        {
            // log the invokation of the request
            _logger.LogInformation("GetAll products api was called by User X");

            // INPUT VALIDATION
            // if input is invalid, such as an incompatible data type is submitted as a Guid, log the error and return 400:
            // _logger.LogError("relevant error message");
            // return BadRequest("relevant error message");

            // AUTHENTICATION & AUTHORIZATION LOGIC
            // if not authenticated and has to be, log the error and return 401
            // if not authorized, log the error and return 403

            var allBrandProducts = await _context
                .Products
                .Where(product => product.BrandId == brandId)
                .Select(product => new ProductGetDto
                {
                    Id = product.Id,
                    ParentId = product.ParentId,
                    Price = product.Price,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Brand = new BrandGetDto
                    {
                        Id = product.BrandId,
                        Name = product.Brand.Name
                    },
                    CreatedAt = product.CreatedAt,
                    CreatedBy = product.CreatedBy ?? "",
                    UpdatedAt = product.UpdatedAt,
                    UpdatedBy = product.UpdatedBy ?? ""
                }).ToListAsync();

            // log the successful completion of call
            _logger.LogInformation("relevant logging info");

            return allBrandProducts;
        }


        // POST: /brands/{brandId}/products
        // will create a product based on the attributes submitted in the payload & saves it into the database
        [HttpPost("brands/{brandId}/products")]
        public async Task<IActionResult> Post(Guid brandId, [FromBody] ProductCreateDto model)
        {
            // log the request
            // ...

            // INPUT VALIDATION
            // input validation logic should be performed and 400 be returned in case of wrong request submissions, for example if a price lower than $1 was unacceptable:
            if (model.Price < 1)
            {
                // log the failure
                return BadRequest("Price cannot be lower than $1");
            }

            // Another example, is making sure the brand id exists:
            var brand = _context.Brands.Find(brandId);
            if (brand is null)
            {
                // log the failure
                return BadRequest($"Brand with id {brandId} does not exist.");
            }


            // AUTHENTICATION & AUTHORIZATION LOGIC
            // if not authenticated and has to be, log the error and return 401
            // if not authorized, log the error and return 403


            var product = new Product
            {
                Id = Guid.NewGuid(),
                BrandId = brandId,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                ParentId = model.ParentId,
                Title = model.Title,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = "Current user's name",
                UpdatedBy = "Current user's name",
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // log the successful execution
            _logger.LogInformation($"Product {product.Id} created by user X.");

            return StatusCode(201, product.Id);
        }


        ///
        /// Other potential endpoints to be developed:
        /// 
        /// 
        /// 
        // GET: /brands/{brandId}/Products/{productId}
        // will return the specific product if exists

        // PUT: /brands/{brandId}/Products/{productId}
        // will update the entity based on the attributes submitted in the payload

        // DELETE: /brands/{brandId}/Products/{productId}
        // will delete the entity if exists


    }
}