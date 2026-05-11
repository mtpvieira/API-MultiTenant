namespace MultiTenantSolution.Domain.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string tenantId { get; set; }
    }
}
