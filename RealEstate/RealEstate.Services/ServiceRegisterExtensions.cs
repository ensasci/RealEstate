using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Services.Domains.Adverts;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.Domains.Users;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Services.EntityFramework.Context;
using RealEstate.Services.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services
{
    public static  class ServiceRegisterExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<RealEstateContext>(provider =>
            {
                provider.UseSqlServer("Server=DESKTOP-4FAV1LC\\SQLEXPRESS; Database=RealEstateDb;TrustServerCertificate=True; Trusted_connection=true;");
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAdvertService, AdvertService>(); 
            services.AddScoped<IFavoriteAdvertService, FavoriteAdvertsService>(); 
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
