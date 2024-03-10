namespace AspCoreUsersMiddlewareWebApplication
{
    public class ErrorHandlerMiddleware
    {
        readonly RequestDelegate next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);
            var statusCode = context.Response.StatusCode;

            switch(statusCode)
            {
                case StatusCodes.Status403Forbidden:
                    await context.Response.WriteAsync("Auth is invalid");
                    break;
                case StatusCodes.Status404NotFound:
                    await context.Response.WriteAsync("Page not found");
                    break;
            }
        }
    }
}
