using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System;

namespace Backend
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      Console.WriteLine(Environment.GetEnvironmentVariable("DB_SERVER"));
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<MyDbContext>();

        // Perform database operations using dbContext
        // For example, dbContext.Database.Migrate();
      }

      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.ConfigureServices((hostContext, services) =>
                  {
                  var server = Environment.GetEnvironmentVariable("DB_SERVER");
                  var database = Environment.GetEnvironmentVariable("DB_DATABASE");
                  var username = Environment.GetEnvironmentVariable("DB_USERNAME");
                  var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
                  var connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
                  var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

                  services.AddDbContext<MyDbContext>(options =>
                          options.UseMySql(connectionString, serverVersion));

                  services.AddControllers();
                  services.AddEndpointsApiExplorer();
                  services.AddSwaggerGen();
                  services.AddCors();
                  DotNetEnv.Env.Load();
                })
                  .Configure(app =>
                  {
                  var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

                  if (env.IsDevelopment())
                  {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                  }

                  app.UseHttpsRedirection();
                  app.UseCors(builder => builder
                          .AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());

                  app.UseAuthorization();
                  app.UseRouting();
                  app.UseEndpoints(endpoints =>
                      {
                      endpoints.MapControllers();
                    });
                });
            });
  }
}
