using MultiTenantSolution.Extensions;
using MultiTenantSolution.Provider;

namespace MultiTenantSolution.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Atribui o TenantId ao TenantData para que ele possa ser utilizado posteriormente na aplicação.
        /// O TenantId é obtido a partir do HttpContext, utilizando a extensão GetTenantId() definida em HttpContextExtensions.cs.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var tenant = httpContext.RequestServices.GetRequiredService<TenantData>();

            tenant.TenantId = httpContext.GetTenantId();

            await _next(httpContext);
        }
    }
}
