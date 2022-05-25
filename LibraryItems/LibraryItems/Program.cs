using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using LibraryItems.Data;
using LibraryItems.Data.Repositories;
using LibraryItems.Models;
using LibraryItems.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryItemContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<LibraryItem, int>, LibItemRepository>();
builder.Services.AddScoped<ICrudService<LibraryItem, int>, LibraryItemService>();
builder.Services.AddScoped<ICrudRepository<Library, int>, LibraryRepository>();
builder.Services.AddScoped<ICrudService<Library, int>, LibraryService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

UpdateDatabase(app);

app.Run();

 static void UpdateDatabase(IApplicationBuilder app)
{
    using var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();
    using var context = serviceScope.ServiceProvider.GetService<LibraryItemContext>();
    context.Database.Migrate();
}
