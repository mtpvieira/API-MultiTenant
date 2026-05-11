using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenantSolution.Data;
using MultiTenantSolution.Domain;

namespace MultiTenantSolution.Controllers
{
    [ApiController]
    [Route("{tenant}/[controller]")]
    public class ProductController : ControllerBase
    {
        private ILogger<PersonController> _logger;

        public ProductController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get([FromServices]AppDbContext db)
        {
            var products = db.Products.AsNoTracking().ToArray();

            return products;
        }
    }
}
