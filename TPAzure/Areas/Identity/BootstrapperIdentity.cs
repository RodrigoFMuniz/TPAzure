using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPAzure.Areas.Identity
{
    public static class BootstrapperIdentity
    {
        public static void RegisterAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //Seção criada para futura autenticação por outros meios ex. Google auth
        }
    }
}
