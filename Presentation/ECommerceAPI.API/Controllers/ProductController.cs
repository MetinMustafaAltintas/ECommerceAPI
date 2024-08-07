using ECommerceAPI.Application.Repositories;
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
        public async void Get() 
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id=Guid.NewGuid(), Name="Product1",Price=100,CreatedDate=DateTime.UtcNow,Stock = 10},
                new() { Id=Guid.NewGuid(), Name="Product2",Price=200,CreatedDate=DateTime.UtcNow,Stock = 20},
                new() { Id=Guid.NewGuid(), Name="Product3",Price=300,CreatedDate=DateTime.UtcNow,Stock = 30},
            });
            await _productWriteRepository.SaveAsync();
        }

    }
}
