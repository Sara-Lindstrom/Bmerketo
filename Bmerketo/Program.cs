
using Bmerketo.Contexts;
using Bmerketo.Factories;
using Bmerketo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<IdentityContext>()
  .AddClaimsPrincipalFactory<CustomClaimsPrincipleFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/";
});

builder.Services.AddScoped<AccountServices>();
builder.Services.AddScoped<ProductServices>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ContactService>();

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
