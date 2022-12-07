using Core.Contracts;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace DataAccess.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("postgres");
            services.AddTransient((sp) => new NpgsqlConnection(connectionString));
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IKudosRepository, KudosRepository>();
            services.AddTransient<IReasonRepository, ReasonRepository>();
        }
    }
}
