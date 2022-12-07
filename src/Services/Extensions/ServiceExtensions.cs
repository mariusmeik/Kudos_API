using Core.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddTransient<IEmployeeService, EmployeeService>();
            service.AddTransient<IKudosService, KudosService>();
            service.AddTransient<IReportService, ReportService>();
        }
    }
}
