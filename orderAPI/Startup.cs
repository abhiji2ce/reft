using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using orderAPI.Services;
using Microsoft.OpenApi.Models;


namespace orderAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /*services.AddScoped<IMongoClient>(sp =>
            {
                var mongoUrl = MongoUrl.Create(Configuration.GetConnectionString("MongoDb"));
                return new MongoClient(mongoUrl);
            }//);*/

            string connectionString = Configuration.GetConnectionString("MongoDbConnection");
            string databaseName = Configuration["MongoDbSettings:DatabaseName"]; 

            services.AddScoped<MongoDbService>(provider => new MongoDbService(connectionString, databaseName));

          

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });

            services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 5083; // Specify the HTTPS port used by your application
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
      
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Production error handling
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<MyCustomMiddleware>();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        }
    }
    
}















/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
using Microsoft.AspNetCore.Models;
using MongoDB.Driver;
using orderAPI.Controllers.OrderController;

namespace orderAPI
/*{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        /*{
          services.AddSingleton<MongoService>(sp =>
            {
                var config = Configuration.GetSection("MongoDB");
                var mongoUrl = config["Url"];
                var dbName = config["Database"];
                var collectionName = config["Collection"];
                return new MongoService(mongoUrl, dbName, collectionName);
            });

            services.AddControllers();
        }
           
            






            /*var mongoSettings = Configuration.GetSection("MongoDB").Get<MongoDBSettings>();
            services.AddSingleton<IMongoClient>/*(s => new MongoClient(mongoSettings.ConnectionString));*/

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        /*{
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization/*();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }*/

   /* public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
/*}*/

/*namespace orderAPI
{
public class Startup
{
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<MongoService>(sp =>
    {
        var config = Configuration.GetSection("MongoDB");
        var mongoUrl = config["Url"];
        var dbName = config["Database"];
        var collectionName = config["Collection"];
        return new MongoService(mongoUrl, dbName, collectionName);
    });

    services.AddControllers();
}*/