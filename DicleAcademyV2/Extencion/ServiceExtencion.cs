using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.Contracts;
using Repositories.EF_Core;
using Services.Abstract;
using Services.Contracts;
using Services.EFCore;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text;

namespace DicleAcademyV2.Extencion
{
    public static class ServiceExtencion
    {
        public static void ConfiguratioSQLContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Repositories")));
        }
        public static void ConfiguerRepostoryManager(this IServiceCollection services)
        {

            //Repo base entitlere göre düzenlenecek hepsi eklenecek 



            services.AddScoped<IRepositoryAbout, RepositoryAbout>();
            services.AddScoped<IRepositoryLogo, RepositoryLogo>();
            services.AddScoped<IRepositoryLatestCauses, RepositoryLatestCauses>();
            services.AddScoped<IRepositoryOurMission, RepositoryOurMission>();
            services.AddScoped<IRepositoryOurTeam, RepostoryOurTeam>();
            services.AddScoped<IRepositorySocialMedia, RepositorySocialMedia>();
            services.AddScoped<IRepositorySocietyContact, RepositorySocietyContact>();
            services.AddScoped<IRepositorySocietyContactAdmin, RepositorySocietyContactAdmin>();
            services.AddScoped<IRepositorySocietyHeader, RepositorySocietyHeader>();
            services.AddScoped<IRepositorySubscribe, RepositorySubscribe>();
            services.AddScoped<IRepositoryUser, RepositoryUser>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();


            //repostory Referanslar
            services.AddScoped<IRepositoryBase<Logo>, RepositoryBase<Logo>>();
            services.AddScoped<IRepositoryBase<User>, RepositoryBase<User>>();
            services.AddScoped<IRepositoryBase<Aboute>, RepositoryBase<Aboute>>();
            services.AddScoped<IRepositoryBase<LatestCauses>, RepositoryBase<LatestCauses>>();
            services.AddScoped<IRepositoryBase<OurMission>, RepositoryBase<OurMission>>();
            services.AddScoped<IRepositoryBase<OurTeam>, RepositoryBase<OurTeam>>();
            services.AddScoped<IRepositoryBase<SocialMedia>, RepositoryBase<SocialMedia>>();
            services.AddScoped<IRepositoryBase<SocietyContact>, RepositoryBase<SocietyContact>>();
            services.AddScoped<IRepositoryBase<SocietyContactAdmin>, RepositoryBase<SocietyContactAdmin>>();
            services.AddScoped<IRepositoryBase<SocietyHeader>, RepositoryBase<SocietyHeader>>();
            services.AddScoped<IRepositoryBase<Subscribe>, RepositoryBase<Subscribe>>();
        }
        public static void ConfiguerServiceManager(this IServiceCollection services)
        { // service referanslar
            services.AddScoped<ILogoService, LogoService>();
            services.AddScoped<INewAbouteService, NewAbouteService>();
            services.AddScoped<ILatestCausesService, LatestCausesService>();
            services.AddScoped<IOurMissionService, OurMissionService>();
            services.AddScoped<IOurTeamService, OurTeamService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<ISocietyContactAdminService, SocietyContactAdminService>();
            services.AddScoped<ISocietyContactService, SocietyContactService>();
            services.AddScoped<ISocietyHeaderService, SocietyHeaderService>();
            services.AddScoped<ISubscribeService, SubscribeService>();
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IUserService, UserService>();



            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();



            services.AddScoped<Services.Contracts.IAuthenticationService, Services.EFCore.AuthenticationService>();


        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>
                (
                    opts =>
                    {
                        opts.Password.RequireDigit = true;
                        opts.Password.RequireLowercase = true;
                        opts.Password.RequireUppercase = true;
                        opts.Password.RequireNonAlphanumeric = true;
                        opts.Password.RequiredLength = 8;

                        opts.User.RequireUniqueEmail = true;

                    }
                ).AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings"); 
            var secretKey = jwtSettings["SecretKey"];
            
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login"; 
                })
                .AddJwtBearer(options =>
                {
                    var jwtSettings = configuration.GetSection("JwtSettings");
                    var secretKey = jwtSettings["SecretKey"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["ValidateIssue"],
                        ValidAudience = jwtSettings["ValidateAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });


        }


    }
}
