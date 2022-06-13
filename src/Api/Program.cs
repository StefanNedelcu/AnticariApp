using AnticariApp.Data.Context;
using AnticariApp.Utils.Configuration;
using AnticariApp.Application.Common;
using NetCore.AutoRegisterDi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ACContext>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.RegisterAssemblyPublicNonGenericClasses(typeof(DataService).Assembly)
    .Where(c => c.Name.EndsWith("Service"))
    .AsPublicImplementedInterfaces();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnticariApp API");
        c.RoutePrefix = "swagger";
    });
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
