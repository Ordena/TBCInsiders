using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Persistence;
using TBCInsiders.Management.ApplicationCore.Interfaces.Services;
using TBCInsiders.Management.Infrastructure.Persistence.Data;
using TBCInsiders.Management.Infrastructure.Persistence.Repositories;
using TBCInsiders.Management.Infrastructure.Services;

namespace TBCInsiders.Management.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPhoneNumberService, PhoneNumberService>();
            services.AddScoped<IUserConnectionService, UserConnectionService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IImageService, ImageService>();
            return services;
        }
    }
}
