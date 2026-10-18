var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Render terminates public HTTPS and forwards traffic to this HTTP container.
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

// Render provides PORT. Locally the app is available at http://localhost:10000.
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");
