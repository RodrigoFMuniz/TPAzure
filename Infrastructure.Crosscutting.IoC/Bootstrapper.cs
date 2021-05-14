
using AutoMapper;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Service.Services;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Crosscutting.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterTpAzureServices(
         this IServiceCollection services,
         IConfiguration configuration)
        {
            //services.AddScoped<IPaisAppService, PaisAppService>();
            //services.AddScoped<IIdiomaAppService, IdiomaAppService>();

            services.AddScoped<IPaisService, PaisService>();
            services.AddScoped<IIdiomaService, IdiomaService>();

            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IIdiomaRepository, IdiomaRepository>();



            services.AddDbContext<PaisIdiomaContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("PaisIdiomaContext")));

            //services.AddScoped<IBlobService, BlobService>(provider =>
            //new BlobService(configuration.GetValue<string>("StorageAccount")));

            
        }
    }
}
