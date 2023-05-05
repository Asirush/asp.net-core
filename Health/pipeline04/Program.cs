using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Debug.WriteLine("Use1 before next");
    await next(); // вызов следующего middleware в цепочке
    Debug.WriteLine("Use1 after next");
});

app.Use(async (context, next) =>
{
    Debug.WriteLine("Use2 before next");
    await next(); // вызов следующего middleware в цепочке
    Debug.WriteLine("Use2 after next");
});

app.Use(async (context, next) =>
{
    Debug.WriteLine("Use3 before next");
    await next(); // вызов следующего middleware в цепочке
    Debug.WriteLine("Use3 after next");
});

app.MapGet("/", () => "Hello World!");

app.Run();
