using FirstTryDDD.API.Services;
using FirstTryDDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstTryDDD.API.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("AppDbContext")));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services) 
        {
            return services.AddScoped<AuthorServices>().AddScoped<BookServices>().AddScoped<ReaderServices>();
        }
    }
}
