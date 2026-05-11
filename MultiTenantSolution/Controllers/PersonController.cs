using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenantSolution.Data;
using MultiTenantSolution.Domain;

namespace MultiTenantSolution.Controllers
{
    [ApiController]
    [Route("{tenant}/[controller]")]
    public class PersonController : ControllerBase
    {
        private ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Person> Get([FromServices]AppDbContext db)
        {
            var people = db.People.AsNoTracking().ToArray() ;

            return people;
        }
    }
}
