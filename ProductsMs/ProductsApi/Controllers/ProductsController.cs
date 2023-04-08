using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Core.Common.Data;
using ProductsApi.Core.Models;
using System.Net;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly AppDbContext _appDbContext;

        public ProductsController(ILogger<ProductsController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var result = await _appDbContext.Products.ToListAsync();
            return Ok(result);
        }

        [HttpPost(Name = "SaveProduct")]
        public async Task<IActionResult> Save()
        {
            ProductModel newProduct = new()
            {
                ProductDescription = "teste1",
                ProductName = "Jeans"
            };

            _appDbContext.Products.Add(newProduct);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}