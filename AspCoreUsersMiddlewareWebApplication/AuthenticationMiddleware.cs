namespace AspCoreUsersMiddlewareWebApplication
{
    public class AuthenticationMiddleware
    {
        readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (string.IsNullOrWhiteSpace(token))
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            else
                await next.Invoke(context);
        }
    }
}
