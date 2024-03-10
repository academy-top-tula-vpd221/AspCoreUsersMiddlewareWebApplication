using AspCoreUsersMiddlewareWebApplication;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Environment.EnvironmentName = "Production";

//app.UseMiddleware<TokenMiddleware>();
//app.UseToken("12345");

//app.Run(async context => await context.Response.WriteAsync("Terminal point"));

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RoutingMiddleware>();

app.Run();
