using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Unicam.Paradigmi.Application.Factories;

namespace Unicam.Paradigmi.Web.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app) {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Use(async (HttpContext context, Func<Task> next) =>
            {
                await next.Invoke();
            });

            app.UseHttpsRedirection(); // primo middleware che controlla se la chiamata è http e blocca l'esecuzione

            app.UseAuthentication();

            app.UseAuthorization(); //se era https controllo le autorizzazioni ed eseguo le operazioni dei servizi

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(
                            res
                            );
                    }
                });
            });

            app.MapControllers(); //sono autorizzato e mappo gli oggetti che vengono chiamati controller
            return app;
        }
    }
}
