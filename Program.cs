using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SajatOldalProba.Data;
using Microsoft.Data.Sqlite;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);


var cultureInfo = new CultureInfo("hu-HU");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/Identity/Account/Register", async context =>
    {
        if (context.User.Identity?.IsAuthenticated == true && context.User.Identity.Name == "Admin")
        {
            context.Response.Redirect("/Identity/Account/Register");
        }
        else
        {
            context.Response.Redirect("/Identity/Account/Login");
        }
        await Task.CompletedTask;
    });
});


app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
