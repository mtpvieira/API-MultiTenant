using MultiTenantSolution.Domain.Abstract;

namespace MultiTenantSolution.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
