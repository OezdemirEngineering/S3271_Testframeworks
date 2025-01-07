using CRM.Common.Contracts;
using CRM.Common.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Backend;

public static class AddDbServicesExtensions
{
    public static IServiceCollection AddDbServices(this IServiceCollection services)
    {
        services.AddTransient<IDbService,DbService>();
        services.AddDbContext<CRMDbContext>(options => options.UseInMemoryDatabase("CRMDatabase"));
        return services;
    }
}
