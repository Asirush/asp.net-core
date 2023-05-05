using pipeline05;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.cme();

app.MapGet("/", () => "Hello World!");

app.Run();
