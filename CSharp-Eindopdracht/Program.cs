using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Dierentuin.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // MVC Controllers + Razor Views
builder.Services.AddControllers();         // API Controllers
builder.Services.AddEndpointsApiExplorer(); // Voor Swagger/Endpoints API-documentatie

// Add Swagger for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Dierentuin API",
        Version = "v1",
        Description = "API voor het beheren van de virtuele dierentuin."
    });
});

// Add Entity Framework and configure the database connection
builder.Services.AddDbContext<ZooContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add other services (e.g., seeding, logging) here if needed

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dierentuin API v1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Gebruik HTTPS Strict Transport Security in productie
}

app.UseHttpsRedirection(); // Redirect HTTP naar HTTPS
app.UseStaticFiles();      // Maak toegang mogelijk tot bestanden in wwwroot

app.UseRouting();

app.UseAuthorization();

// Configure routes for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map API controllers (optional, if separate route handling is needed)
app.MapControllers();

app.Run();
