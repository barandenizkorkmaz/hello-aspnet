var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    // References: https://developer.mozilla.org/en-US/docs/Web/HTTP
    
    // Request Header
    string path = context.Request.Path;
    string method = context.Request.Method;
    
    // Status Codes: Response
    context.Response.StatusCode = 200;
    
    // Response Header
    context.Response.Headers["Team"] = "Besiktas";
    // Overwrite existing `Server` header
    context.Response.Headers["Server"] = "Not Kestrel";
    context.Response.Headers["Content-Type"] = "text/html";
    // Response Body
    await context.Response.WriteAsync("<h1>Hello</h1>");
    await context.Response.WriteAsync("<h2>HTTP!</h2>");
    await context.Response.WriteAsync($"<h3>Url: {path}</h3>");
    await context.Response.WriteAsync($"<h3>Method: {method}</h3>");
    // try: localhost:5097/ and localhost:5097/hello and see the difference!

    // Query String
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }

        if (context.Request.Query.ContainsKey("name"))
        {
            var name = context.Request.Query["name"];
            await context.Response.WriteAsync($"<p>{name}</p>");
        }
    }
    
    // Request Headers
    if (context.Request.Headers.ContainsKey("User-Agent"))
    {
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<p>{userAgent}</p>");
    }

});

app.Run();