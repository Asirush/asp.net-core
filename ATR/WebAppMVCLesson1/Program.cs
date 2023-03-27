using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Serilog.Formatting.Compact;
using WebAppMVCLesson1.Middleware;
using WebAppMVCLesson1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341")
    .WriteTo.Debug(new RenderedCompactJsonFormatter())
    .CreateLogger();

//builder.Host.ConfigureLogging(logingBuilder =>
//{
//    logingBuilder.ClearProviders();
//    logingBuilder
//    // --- seq logging
//    .AddSeq()
//    // --- sys logging
//    .AddDebug()
//    .AddEventLog()
//    .AddConsole();
//});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EFContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

var app = builder.Build();

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img")),
    RequestPath = "/images"
});

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

app.UseAuthorization();

//app.UseMiddleware<UsePageStatistic>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
