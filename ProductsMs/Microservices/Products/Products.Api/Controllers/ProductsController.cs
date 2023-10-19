using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Api.Core.Common.Data;
using Products.Api.Core.Models;
using Products.Api.Entities;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductsDbContext _appDbContext;

        public ProductsController(ILogger<ProductsController> logger, ProductsDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> Get()
        {
            var result = await _appDbContext.Products.ToListAsync();
            return Ok(result);
        }

        [HttpPost(Name = "SaveProduct")]
        public async Task<IActionResult> Save()
        {
            ProductEntity newProduct = new()
            {
                ProductDescription = "teste2",
                ProductName = "Jeans2"
            };

            _appDbContext.Products.Add(newProduct);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}