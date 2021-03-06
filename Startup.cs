using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Amazen.Repositories;
using Amazen.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace Amazen
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAuthentication(options =>
            {
              options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
              options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
              options.Audience = Configuration["Auth0:Audience"];

            });

      // NOTE This is akin the the whitelists in Node.js, allows sites listed on lines 53 & 54 to make requests to server, these methods must be finalized in configure
      services.AddCors(options =>
    {
      options.AddPolicy("CorsDevPolicy", builder =>
      {
        builder
        .WithOrigins(new string[]{
        "http://localhost:8080",
        "http://localhost:8081"

        }).AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
      });
    });

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Amazen", Version = "v1" });
      });
      services.AddScoped<IDbConnection>(x => CreateDbConnection());
      services.AddTransient<ProfileService>();
      services.AddTransient<ProfileRepository>();
      services.AddTransient<ProductsService>();
      services.AddTransient<ProductsRepository>();
      services.AddTransient<WishService>();
      services.AddTransient<WishRepository>();
      services.AddTransient<ProductWishListService>();
      services.AddTransient<ProductWishListRepository>();
    }

    private IDbConnection CreateDbConnection()
    {
      string connectionString = Configuration.GetSection("db").GetValue<string>("gearhost");
      return new MySqlConnection(connectionString);
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Amazen v1"));
        app.UseCors("CorsDevPolicy");
      }
      Auth0ProviderExtension.ConfigureKeyMap(new List<string>() { "id" });

      app.UseHttpsRedirection();

      app.UseRouting();


      app.UseAuthentication();
      app.UseAuthorization();
      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
