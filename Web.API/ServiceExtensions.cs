using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            #region install AutoMapper.Extensions.Microsoft.DependencyInjection

            #endregion
            #region Add Profile directory to work with Automapper

            #endregion
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }




    }
}
