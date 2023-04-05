using Gaez.BakeryHouse.Data;
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

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
