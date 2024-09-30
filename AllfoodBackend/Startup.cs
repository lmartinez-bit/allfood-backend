using AllfoodBackend.data;
using AllfoodBackend.data.Repositories;
using Microsoft.Extensions.Configuration;

namespace AllfoodBackend
{
    public class Startup
    {

        readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var postgreSQLConfiguration = new PostgreSQLConfiguration(configuration.GetConnectionString("PostgreSQLConnection"));
            services.AddSingleton(postgreSQLConfiguration);
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
