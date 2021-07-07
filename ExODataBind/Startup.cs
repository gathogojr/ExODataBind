using System.Linq;
using ExODataBind.Models;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData;

namespace ExODataBind
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Customer>("Customers");
            modelBuilder.EntitySet<Order>("Orders");

            services.AddControllers()
                .AddOData(options =>
                {
                    options.Select().Filter().OrderBy().Count().Expand().SetMaxTop(null).AddRouteComponents("odata", modelBuilder.GetEdmModel());
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(routeBuilder =>
            {
                routeBuilder.MapControllers();
            });
        }
    }
}
