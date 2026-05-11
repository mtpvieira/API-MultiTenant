namespace MultiTenantSolution.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetTenantId(this HttpContext httpContext)
        {
            //obtém o tenant presente na URL, considerando que a URL tem o formato http://domain.com/tenant/endpoint

            var tenant = httpContext.Request.Path.Value.Split("/", System.StringSplitOptions.RemoveEmptyEntries)[0];

            return tenant;
        }
    }
}
