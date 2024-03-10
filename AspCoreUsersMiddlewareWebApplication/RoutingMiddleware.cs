namespace AspCoreUsersMiddlewareWebApplication
{
    public class RoutingMiddleware
    {
        public RoutingMiddleware(RequestDelegate _) { }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            var response = context.Response;

            if (path == "/")
            {
                await response.WriteAsync("Home Page");
            }
            else if (path == "/about")
            {
                await response.WriteAsync("About Page");
            }
            else if (path == "/contacts")
            {
                await response.WriteAsync("Contacts Page");
            }
            else
                response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
}
