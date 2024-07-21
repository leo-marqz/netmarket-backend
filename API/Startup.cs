﻿
using APPLICATION.Persistence;
using APPLICATION.Persistence.Contracts;
using APPLICATION.Persistence.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add the DbContext
        services.AddDbContext<ApplicationDbContext>( (options) => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")) );

        // Add the Repositories
        services.AddTransient<IProductRepository, ProductRepository>();


        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
