using Microsoft.AspNetCore.Identity;
using RolebaseAuthorization.DBContext;
using RolebaseAuthorization.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDefaultIdentity<IdentityUser>()
       .AddRoles<IdentityRole>() // Add this line to enable role management
       .AddEntityFrameworkStores<ApplicationDBContext>();
var app = builder.Build();
RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
RoleInitializer.InitializeAsync(roleManager).GetAwaiter().GetResult();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
