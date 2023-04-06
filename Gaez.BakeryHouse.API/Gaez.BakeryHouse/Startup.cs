using Gaez.BakeryHouse.Data;
using Gaez.BakeryHouse.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Gaez.BakeryHouse
{
    public class Startup
    {
        #region PROPERTIES
        public IConfiguration Configuration { get; }
        #endregion
        #region CONSTRUCTOR
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion
        #region METHODS
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<GaezDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<CategoryService, CategoryService>();
            services.AddTransient<ProductService, ProductService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoint => endpoint.MapControllers());
        }
        #endregion
    }
}
