using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get() 
        {
            //_productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id=Guid.NewGuid(), Name="Product1",Price=100,CreatedDate=DateTime.UtcNow,Stock = 10},
            //    new() { Id=Guid.NewGuid(), Name="Product2",Price=200,CreatedDate=DateTime.UtcNow,Stock = 20},
            //    new() { Id=Guid.NewGuid(), Name="Product3",Price=300,CreatedDate=DateTime.UtcNow,Stock = 30},
            //});
            //await _productWriteRepository.SaveAsync();

            Product p = await _productReadRepository.GetByIdAsync("8e6317bd-683e-4b03-81f9-9179c158ba60",false);
            p.Name = "Mehmet";
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
          Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
