using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Extensions;
using Unicam.Paradigmi.Application.Options;
using Unicam.Paradigmi.Application.Services;
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
