using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ElectronicsStore.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ElectronicsStoreDataContextConnection") ?? throw new InvalidOperationException("Connection string 'ElectronicsStoreDataContextConnection' not found.");

builder.Services.AddDbContext<ElectronicsStoreDataContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ElectronicsStoreUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ElectronicsStoreDataContext>();

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(builder =>
    {
        builder.JsonSerializerOptions.PropertyNamingPolicy = null;
        builder.JsonSerializerOptions.PropertyNameCaseInsensitive = true;


    });




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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Wellcome}/{id?}");

app.MapRazorPages();   

app.Run();
