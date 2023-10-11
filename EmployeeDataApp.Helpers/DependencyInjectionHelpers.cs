using EmployeeDataApp.DataAccess.DataContext;
using EmployeeDataApp.DataAccess.Implementations;
using EmployeeDataApp.DataAccess.Interfaces;
using EmployeeDataApp.Domain.Models;
using EmployeeDataApp.Services.Implementations;
using EmployeeDataApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDataApp.Helpers
{
    public static class DependencyInjectionHelpers
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<EmployeeDataAppDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\EmployeeDataApp;Database=EmployeeDataAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Employee>, EmployeeRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();

        }

    }
}
