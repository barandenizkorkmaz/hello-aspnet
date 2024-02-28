var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // References: https://developer.mozilla.org/en-US/docs/Web/HTTP
    
    // Status Codes
    context.Response.StatusCode = 400;
    
    // Response Header
    context.Response.Headers["Team"] = "Besiktas";
    // Overwrite existing `Server` header
    context.Response.Headers["Server"] = "Not Kestrel";
    context.Response.Headers["Content-Type"] = "text/html";
    // Response Body
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await context.Response.WriteAsync("<h2>HTTP!</h2>");
    
});

app.Run();