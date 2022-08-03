using System.Net;

namespace ApiFilmes.Middleware
{
    public class ApiKeyMiddleware
    {
        const string ApiKey = "X-API-Key";
        public static string ApikeyAplicacao { get; set; }

        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var apikeyRequest = ObterApiKey(httpContext);

            if(string.IsNullOrEmpty(apikeyRequest))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsync("API key não encontrada");
                return;
            }

            if(!apikeyRequest.Equals(ApikeyAplicacao))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await httpContext.Response.WriteAsync("Acesso não autorizado.");
                return;
            }

            await _next(httpContext);
        }

        private string ObterApiKey(HttpContext httpContext)
        {
            if (httpContext.Request.Headers[ApiKey].Any())
                return httpContext.Request.Headers[ApiKey].First();

            if(httpContext.Request.Query.ContainsKey(ApiKey))
                return httpContext.Request.Query[ApiKey];

            return string.Empty;
        }
    }
}