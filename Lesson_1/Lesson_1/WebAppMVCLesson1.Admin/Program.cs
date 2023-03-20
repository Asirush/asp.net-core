using WebAppMVCLesson1.Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<EFContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Это внедрение зависимости с сопоставлением типа службы и сопоставлением типа реализации
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<IStorage, Storage>();
// use AddScoped to use only one class example
// use AddSigleton is a constant

// внедрение зависимостей для одного типа
builder.Services.AddTransient<ProductSum>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
