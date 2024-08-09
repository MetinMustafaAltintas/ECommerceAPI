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
            _productWriteRepository.AddAsync(new() { Name="C Product", Price = 1.500F ,Stock =10});
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
          Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
