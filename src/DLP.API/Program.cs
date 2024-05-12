using DLP.API.Extensions;
using DLP.Application;
using DLP.Application.Interfaces.Repositories;
using DLP.Application.Interfaces.Services;
using DLP.Application.Services;
using DLP.Infrastructure;
using DLP.Persistence;
using DLP.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DLP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            builder.Services.AddApiAuthentication(configuration);
            builder.Services.AddHttpContextAccessor();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
                });

            builder.Services.AddScoped<IUserRepository, UsersRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ISectionService, SectionService>();
            builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddScoped<IPasswrodHasher, PasswrodHasher>();

            builder.Services
                .AddPersistence(configuration).AddApplication();
            //builder.Services.AddAutoMapper(typeof(DataBaseMappings));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
