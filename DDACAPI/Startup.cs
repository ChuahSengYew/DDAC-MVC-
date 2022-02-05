using DDACAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DDACAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddControllers();
            services.AddCors(options =>
                options.AddDefaultPolicy(
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
            );

            //Local MS SQL
            // var connection = Configuration.GetConnectionString("MusicConnectionLocal");


            //RDS

            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("MusicConnection"));
            builder.Password = Configuration["DbPassword"];
            builder.UserID = Configuration["DbUser"];
            var connection = builder.ConnectionString;
            // services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<MusicContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });
        }
    }
}
