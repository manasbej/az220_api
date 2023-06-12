using Microsoft.AspNetCore.Mvc;
using AZ220_API.Model;

using AZ220_API.Application;

namespace AZ301_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly ITableManager _tableManager;

        public ProductController(ITableManager tableManager)
        {
            _tableManager = tableManager;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<List<ProductItem>> Get()
        {
            return await _tableManager.ReadAllProduct();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ProductItem> Get(string id)
        {
            return await _tableManager.ReadProductBykey(id);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<string> Post([FromBody] ProductItem product)
        {
            return await _tableManager.CreateProduct(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
