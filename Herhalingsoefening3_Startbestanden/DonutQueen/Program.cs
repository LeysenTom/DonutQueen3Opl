using DonutQueen.Data;
using DonutQueen.Data.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DonutQueenContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<DonutQueenContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();