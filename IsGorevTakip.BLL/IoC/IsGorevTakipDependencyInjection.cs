using IsGorevTakip.BLL.Abstract;
using IsGorevTakip.BLL.Concrete;
using IsGorevTakip.DAL.Abstract;
using IsGorevTakip.DAL.Concrete;
using IsGorevTakip.DAL.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;

namespace IsGorevTakip.BLL.IoC
{
    public static class IsGorevTakipDependencyInjection
    {
        public static IServiceCollection IoCServices(this IServiceCollection services)
        {
            services.AddDbContext<IsGorevTakipContext>();
            services.AddScoped<IJobWorkService, JobWorkManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();


            services.AddScoped<IJobWorkDAL, EfJobWorkRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyReporsitory>();
            services.AddScoped<IReportatDal, EfReportRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            return services;

        }
    }
}
