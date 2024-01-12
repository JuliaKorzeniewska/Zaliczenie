using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zaliczenie.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ZaliczenieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZaliczenieContext") ?? throw new InvalidOperationException("Connection string 'ZaliczenieContext' not found.")));


builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "deafult",
    pattern: "{controller=Home}/{action=Index}/{id}");

app.Run();
