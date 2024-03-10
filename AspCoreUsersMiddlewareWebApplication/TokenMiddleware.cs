namespace AspCoreUsersMiddlewareWebApplication
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        string tokenPattern;

        public TokenMiddleware(RequestDelegate next, string tokenPattern)
        {
            _next = next;
            this.tokenPattern = tokenPattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];

            if (token == tokenPattern)
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("token is not valid");
            }
        }

        
    }

    static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
