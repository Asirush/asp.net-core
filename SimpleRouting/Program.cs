using Microsoft.AspNetCore.Routing.Constraints;
using SimpleRouting.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

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

app.MapControllerRoute(
    name: "defaultApi",
    pattern: "api/{action}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");


app.Run();
