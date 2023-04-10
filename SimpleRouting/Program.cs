using Microsoft.AspNetCore.Routing.Constraints;
using SimpleRouting.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Razor;
using SimpleRouting.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "MyApp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.Configure<RequestLocalizationOptions>(
    option =>
    {
        var supportedCulture = new[]
        {
            new CultureInfo("en"),
            new CultureInfo("ru"),
            new CultureInfo("kk")
        };
        option.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
        option.SupportedCultures = supportedCulture;
        option.SupportedUICultures = supportedCulture;
        option.AddInitialRequestCultureProvider(
            new CustomRequestCultureProvider(async context =>
            {
                var currentCulture = "en";
                var segment = context.Request.Path.Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (segment.Length >= 2)
                {
                    string lastSegment = segment[segment.Length - 1];
                    currentCulture = lastSegment;
                }

                var requestCulture = new ProviderCultureResult(currentCulture);
                return await Task.FromResult(requestCulture);
            }));

        //option.AddInitialRequestCultureProvider(new MyCultureprovider());
    });

builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSession(); // sessions should be higher then auth

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

#region lesson1
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller}/{action}/{id?}",
//        //default value for route parametrs
//        defaults: new
//        {
//            controller = "home",
//            action = "Index",
//            customeConstraint = new UserAgentConstrain("Chrome")
//        },
//        constraints: new
//        {
//            id = new IRouteConstraint()
//        });

//    endpoints.MapControllerRoute(
//        name: "Documents",
//        pattern: "documents/{controller}/{number}/{action}",
//        //default value for route parametrs
//        defaults: new
//        {
//            controller = "invoice",
//            action = "view"
//        },
//        constraints: new
//        {
//            number = new RegexRouteConstraint("[a-z]{2}")
//        });
//});

//// custom route for unknown count of values
//app.MapControllerRoute(
//    name: "CatchAll",
//    pattern: "api/{controller=Home}/{action=Index}/{*data}");

//// custom route for two parameters
//app.MapControllerRoute(
//    name: "TwoParametrRoutee",
//    pattern: "api/{controller=Home}/{action=Index}/{x}/{y}");

//// custom route for api
//app.MapControllerRoute(
//    name: "default",
//    pattern: "api/{controller=Home}/{action=Index}/{id?}");

//// определение route template
//app.MapControllerRoute(
//    name: "default", // название 
//    pattern: "{controller=Home}/{action=Index}/{id?}"); // route template состоящий из двух сегментов, home and index are default values

//// comment everything above and leave this one if you use one attribs: [Route("Synny")]
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

#endregion

//app.MapControllerRoute(
//    name: "defaultApi",
//    pattern: "api/{action}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "langs",
    pattern: "en",
    defaults: new {controller = "Home", action = "Index"});

app.MapControllerRoute(
    name: "langs",
    pattern: "kk",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "langs",
    pattern: "ru",
    defaults: new { controller = "Home", action = "Index" });


app.Run();
