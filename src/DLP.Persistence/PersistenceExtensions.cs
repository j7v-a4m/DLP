using DLP.Application.Interfaces.Repositories;
using DLP.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLP.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
            });

            services.AddScoped<ICourseRepository, CourseRepository>();
            //services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
