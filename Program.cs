using Auth0.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ReaderStore.Models;
using ReaderStore.Data;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
});
 


// Add services to the container.
//builder.Services.AddControllersWithViews();
/*builder.Services.AddControllersWithViews()
.AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNameCaseInsensitive= true;
    options.JsonSerializerOptions.PropertyNamingPolicy= null;
});*/

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
