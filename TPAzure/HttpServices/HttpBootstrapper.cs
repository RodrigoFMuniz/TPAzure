using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPAzure.HttpServices.Implementations;

namespace TPAzure.HttpServices
{
    public static class HttpBootstrapper
    {
        public static void RegisterHttpClients(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //var paisAddress = configuration.GetValue<Uri>("TPAzure:Pais");
            //services.AddHttpClient<IPaisHttpService, PaisHttpService>(x => x.BaseAddress = paisAddress);

            //var idiomaAddress = configuration.GetValue<Uri>("TPAzure:Idioma");
            //services.AddHttpClient<IIdiomaHttpService, IdiomaHttpService>(x => x.BaseAddress = idiomaAddress);

            services.AddHttpClient<IPaisHttpService, PaisHttpService>(x => x.BaseAddress = new Uri("https://localhost:44360/api/Pais"));
            services.AddHttpClient<IIdiomaHttpService, IdiomaHttpService>(x => x.BaseAddress = new Uri("https://localhost:44360/api/Idioma"));
        }

    }
}
