using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Models.Extensions;
using Unicam.Paradigmi.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);


var app = builder.Build();

app.AddWebMiddleware()
    .AddApplicationMiddleware();

app.Run();
