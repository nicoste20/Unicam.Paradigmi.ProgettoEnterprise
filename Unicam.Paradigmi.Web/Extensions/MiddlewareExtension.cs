namespace Unicam.Paradigmi.Web.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app) {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            //Middleware per mappare i controller
            app.MapControllers(); 
            return app;
        }
    }
}
