using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebStoreBackend.Data;
using WebStoreBackend.Models;

namespace WebStoreBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
            => await _db.Products.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
        }
    }
}// Test
