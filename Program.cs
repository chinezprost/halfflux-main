using System.Configuration;
using HALFFLUX_main_website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using Westwind.AspNetCore.LiveReload;
using ConfigurationSection = Microsoft.Extensions.Configuration.ConfigurationSection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ApplicationContexts>(options => options.UseMySQL((string)new AppSettingsReader().GetValue("ConnectionStrings", typeof(string))));
builder.Services.AddDbContext<ApplicationContexts>(options => options.UseMySQL("Server=127.0.0.1;Port=3306;Database=halfflux_live;Uid=root;Pwd=;Convert Zero Datetime=True"));
builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddLiveReload();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseLiveReload();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseRouting();
app.UseSession();
app.MapRazorPages();

app.Run();