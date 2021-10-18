using Booking.API.Middleware;
using Booking.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwagger();
            services.AddDatabase(_configuration);
            services.AddIdentity();
            services.AddServices();
            services.AddRepositories();
            services.AddAutoMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseCors(corsPolicyBuilder =>
                   corsPolicyBuilder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
            );
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking v1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandler>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default","{controller=Apartment}/{action=index}");
            });
        }
    }
}
