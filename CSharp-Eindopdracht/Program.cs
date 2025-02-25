using CSharp_Eindopdracht.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Voeg services toe aan de container
builder.Services.AddControllersWithViews(); // Voor de MVC-webinterface
builder.Services.AddRazorPages(); // Voor Razor Views

// Configureren van de DbContext met de connection string uit appsettings.json
builder.Services.AddDbContext<ZooContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configureer Swagger voor API-documentatie (optioneel, handig voor API's)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Gedetailleerde foutmeldingen in ontwikkelmodus
    app.UseSwagger();               // API-documentatie in dev-modus
    app.UseSwaggerUI();             // Swagger UI voor interactie met de API
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Gebruik aangepaste foutpagina
    app.UseHsts(); // Forceer HTTPS in productie
}

app.UseHttpsRedirection(); // Redirect HTTP-verzoeken naar HTTPS
app.UseStaticFiles();      // Serve bestanden uit wwwroot (CSS, JS, afbeeldingen)

app.UseRouting();          // Configureer routing voor controllers en Razor Views

app.UseAuthorization();    // (Optioneel) Middleware voor authenticatie/autorisatie

// Configureer endpoints voor de applicatie
app.UseEndpoints(endpoints =>
{
    // Route voor MVC Controllers
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    // Route voor Razor Pages (optioneel)
    endpoints.MapRazorPages();
});

app.Run(); // Start de applicatie
