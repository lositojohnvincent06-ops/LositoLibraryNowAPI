var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Render port setup
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");


// Optional: HTTPS redirect (can keep, but Render already handles HTTPS)
app.UseHttpsRedirection();

// ⭐ ADD ROOT ROUTE (THIS FIXES YOUR 404)
app.MapGet("/", () => "LositoLibraryNowAPI is running 🚀");

// Controllers
app.MapControllers();

app.Run();